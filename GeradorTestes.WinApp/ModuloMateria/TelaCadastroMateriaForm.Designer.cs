namespace GeradorTestes.WinApp.ModuloMateria
{
    partial class TelaCadastroMateriaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkMarcarDisciplina = new System.Windows.Forms.CheckBox();
            this.cmbDisciplinas = new System.Windows.Forms.ComboBox();
            this.checkMarcarPrimeiraSerie = new System.Windows.Forms.CheckBox();
            this.checkMarcarSegundaSerie = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(93, 48);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(176, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(93, 19);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(176, 23);
            this.txtNumero.TabIndex = 3;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(298, 246);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(80, 39);
            this.btnGravar.TabIndex = 4;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(384, 246);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 39);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // checkMarcarDisciplina
            // 
            this.checkMarcarDisciplina.AutoSize = true;
            this.checkMarcarDisciplina.Location = new System.Drawing.Point(36, 114);
            this.checkMarcarDisciplina.Name = "checkMarcarDisciplina";
            this.checkMarcarDisciplina.Size = new System.Drawing.Size(184, 19);
            this.checkMarcarDisciplina.TabIndex = 6;
            this.checkMarcarDisciplina.Text = "Habilitar Seleção de Disciplina";
            this.checkMarcarDisciplina.UseVisualStyleBackColor = true;
            this.checkMarcarDisciplina.CheckedChanged += new System.EventHandler(this.checkMarcarDisciplina_CheckedChanged);
            // 
            // cmbDisciplinas
            // 
            this.cmbDisciplinas.FormattingEnabled = true;
            this.cmbDisciplinas.Location = new System.Drawing.Point(36, 139);
            this.cmbDisciplinas.Name = "cmbDisciplinas";
            this.cmbDisciplinas.Size = new System.Drawing.Size(233, 23);
            this.cmbDisciplinas.TabIndex = 7;
            // 
            // checkMarcarPrimeiraSerie
            // 
            this.checkMarcarPrimeiraSerie.AutoSize = true;
            this.checkMarcarPrimeiraSerie.Location = new System.Drawing.Point(36, 190);
            this.checkMarcarPrimeiraSerie.Name = "checkMarcarPrimeiraSerie";
            this.checkMarcarPrimeiraSerie.Size = new System.Drawing.Size(60, 19);
            this.checkMarcarPrimeiraSerie.TabIndex = 11;
            this.checkMarcarPrimeiraSerie.Text = "1 Série";
            this.checkMarcarPrimeiraSerie.UseVisualStyleBackColor = true;
            this.checkMarcarPrimeiraSerie.CheckedChanged += new System.EventHandler(this.checkMarcarPrimeiraSerie_CheckedChanged);
            // 
            // checkMarcarSegundaSerie
            // 
            this.checkMarcarSegundaSerie.AutoSize = true;
            this.checkMarcarSegundaSerie.Location = new System.Drawing.Point(36, 215);
            this.checkMarcarSegundaSerie.Name = "checkMarcarSegundaSerie";
            this.checkMarcarSegundaSerie.Size = new System.Drawing.Size(60, 19);
            this.checkMarcarSegundaSerie.TabIndex = 12;
            this.checkMarcarSegundaSerie.Text = "2 Série";
            this.checkMarcarSegundaSerie.UseVisualStyleBackColor = true;
            this.checkMarcarSegundaSerie.CheckedChanged += new System.EventHandler(this.checkMarcarSegundaSerie_CheckedChanged);
            // 
            // TelaCadastroMateriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 297);
            this.Controls.Add(this.checkMarcarSegundaSerie);
            this.Controls.Add(this.checkMarcarPrimeiraSerie);
            this.Controls.Add(this.cmbDisciplinas);
            this.Controls.Add(this.checkMarcarDisciplina);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TelaCadastroMateriaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Materias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkMarcarDisciplina;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.CheckBox checkMarcarPrimeiraSerie;
        private System.Windows.Forms.CheckBox checkMarcarSegundaSerie;
    }
}