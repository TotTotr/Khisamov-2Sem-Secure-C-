namespace Secure
{
    partial class FormProductComponent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelComponents = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelComponents
            // 
            this.labelComponents.AutoSize = true;
            this.labelComponents.Location = new System.Drawing.Point(12, 32);
            this.labelComponents.Name = "labelComponents";
            this.labelComponents.Size = new System.Drawing.Size(63, 13);
            this.labelComponents.TabIndex = 0;
            this.labelComponents.Text = "Компонент";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 68);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(66, 13);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(206, 103);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(92, 22);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(323, 103);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 22);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(84, 65);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(329, 20);
            this.textBoxCount.TabIndex = 4;
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(81, 32);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(329, 21);
            this.comboBoxComponent.TabIndex = 5;
            // 
            // FormProductComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 148);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelComponents);
            this.Name = "FormProductComponent";
            this.Text = "Компонент изделия";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComponents;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxComponent;
    }
}