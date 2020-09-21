using SecureLogic.BindingModels;
using SecureLogic.BusinessLogic;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace Secure
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IKomlectLogic logicP;
        private readonly MainLogic logicM;
        private readonly IClientLogic logicC;


        public FormCreateOrder(IKomlectLogic logicP, MainLogic logicM, IClientLogic logicC)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicM = logicM;
            this.logicC = logicC;
        }


        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listP = logicP.Read(null);

                if (listP != null)

                {

                    comboBoxKomlect.DisplayMember = "KomlectName";
                    comboBoxKomlect.ValueMember = "Id";
                    comboBoxKomlect.DataSource = listP;
                    comboBoxKomlect.SelectedItem = null;
                }
                var listC = logicC.Read(null);

                if (listC != null)
                {
                    comboBoxClient.DisplayMember = "ClientFIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.SelectedItem = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }


        private void CalcSum()
        {
            if (comboBoxKomlect.SelectedValue != null &&
 !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxKomlect.SelectedValue);
                    KomlectViewModel Komlect = logicP.Read(new KomlectConcreteBindingModel
                    {
                        Id =
                    id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * Komlect?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxKomlect.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    KomlectId = Convert.ToInt32(comboBoxKomlect.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    Sum = Convert.ToInt32(textBoxSum.Text)
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

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxKomlect_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}
