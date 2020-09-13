using SecureLogic.BindingModels;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace Secure
{
    public partial class FormKomlect : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IKomlectLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> KomlectComponents;
        public FormKomlect(IKomlectLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormKomlect_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    KomlectViewModel view = logic.Read(new KomlectConcreteBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.KomlectName;
                        textBoxPrice.Text = view.Price.ToString();
                        KomlectComponents = view.KomlectComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                KomlectComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (KomlectComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in KomlectComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
   MessageBoxIcon.Error);
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (KomlectComponents == null || KomlectComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new KomlectConcreteBindingModel
                {
                    Id = id,
                    KomlectName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    KomlectComponents = KomlectComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        KomlectComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormKomlectComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = KomlectComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    KomlectComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormKomlectComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (KomlectComponents.ContainsKey(form.Id))
                {
                    KomlectComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    KomlectComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }
    }
}
