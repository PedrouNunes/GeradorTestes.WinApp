namespace GeradorTestes.WinApp.ModuloTeste
{
    partial class TelaCadastroTesteForm
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
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDisciplinas = new System.Windows.Forms.ComboBox();
            this.checkBoxProvaRecuperacao = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.DateTimePicker();
            this.txtQtdQuestoes = new System.Windows.Forms.TextBox();
            this.btnSortearQuestoes = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkMarcarDisciplina = new System.Windows.Forms.CheckBox();
            this.checkMarcarMateria = new System.Windows.Forms.CheckBox();
            this.listQuestoes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(98, 34);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(167, 23);
            this.txtNumero.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Título";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(98, 69);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(167, 23);
            this.txtTitulo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Disciplina";
            // 
            // cmbDisciplinas
            // 
            this.cmbDisciplinas.FormattingEnabled = true;
            this.cmbDisciplinas.Location = new System.Drawing.Point(98, 114);
            this.cmbDisciplinas.Name = "cmbDisciplinas";
            this.cmbDisciplinas.Size = new System.Drawing.Size(167, 23);
            this.cmbDisciplinas.TabIndex = 6;
            // 
            // checkBoxProvaRecuperacao
            // 
            this.checkBoxProvaRecuperacao.AutoSize = true;
            this.checkBoxProvaRecuperacao.Location = new System.Drawing.Point(286, 77);
            this.checkBoxProvaRecuperacao.Name = "checkBoxProvaRecuperacao";
            this.checkBoxProvaRecuperacao.Size = new System.Drawing.Size(148, 19);
            this.checkBoxProvaRecuperacao.TabIndex = 7;
            this.checkBoxProvaRecuperacao.Text = "Prova de Recuperação?";
            this.checkBoxProvaRecuperacao.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Materia";
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Location = new System.Drawing.Point(98, 160);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(167, 23);
            this.cmbMaterias.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Quantidade de Questões";
            // 
            // txtData
            // 
            this.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtData.Location = new System.Drawing.Point(323, 37);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(89, 23);
            this.txtData.TabIndex = 11;
            // 
            // txtQtdQuestoes
            // 
            this.txtQtdQuestoes.Location = new System.Drawing.Point(155, 198);
            this.txtQtdQuestoes.Name = "txtQtdQuestoes";
            this.txtQtdQuestoes.Size = new System.Drawing.Size(110, 23);
            this.txtQtdQuestoes.TabIndex = 12;
            // 
            // btnSortearQuestoes
            // 
            this.btnSortearQuestoes.Location = new System.Drawing.Point(286, 198);
            this.btnSortearQuestoes.Name = "btnSortearQuestoes";
            this.btnSortearQuestoes.Size = new System.Drawing.Size(115, 23);
            this.btnSortearQuestoes.TabIndex = 14;
            this.btnSortearQuestoes.Text = "Sortear Questões";
            this.btnSortearQuestoes.UseVisualStyleBackColor = true;
            this.btnSortearQuestoes.Click += new System.EventHandler(this.btnSortearQuestoes_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(164, 399);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(115, 48);
            this.btnGravar.TabIndex = 15;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(297, 399);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 48);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // checkMarcarDisciplina
            // 
            this.checkMarcarDisciplina.AutoSize = true;
            this.checkMarcarDisciplina.Location = new System.Drawing.Point(286, 116);
            this.checkMarcarDisciplina.Name = "checkMarcarDisciplina";
            this.checkMarcarDisciplina.Size = new System.Drawing.Size(184, 19);
            this.checkMarcarDisciplina.TabIndex = 17;
            this.checkMarcarDisciplina.Text = "Habilitar Seleção de Disciplina";
            this.checkMarcarDisciplina.UseVisualStyleBackColor = true;
            this.checkMarcarDisciplina.CheckedChanged += new System.EventHandler(this.checkMarcarDisciplina_CheckedChanged);
            // 
            // checkMarcarMateria
            // 
            this.checkMarcarMateria.AutoSize = true;
            this.checkMarcarMateria.Location = new System.Drawing.Point(286, 160);
            this.checkMarcarMateria.Name = "checkMarcarMateria";
            this.checkMarcarMateria.Size = new System.Drawing.Size(173, 19);
            this.checkMarcarMateria.TabIndex = 18;
            this.checkMarcarMateria.Text = "Habilitar Seleção de Materia";
            this.checkMarcarMateria.UseVisualStyleBackColor = true;
            this.checkMarcarMateria.CheckedChanged += new System.EventHandler(this.checkMarcarMateria_CheckedChanged_1);
            // 
            // listQuestoes
            // 
            this.listQuestoes.FormattingEnabled = true;
            this.listQuestoes.ItemHeight = 15;
            this.listQuestoes.Location = new System.Drawing.Point(77, 256);
            this.listQuestoes.Name = "listQuestoes";
            this.listQuestoes.Size = new System.Drawing.Size(307, 109);
            this.listQuestoes.TabIndex = 19;
            // 
            // TelaCadastroTesteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 472);
            this.Controls.Add(this.listQuestoes);
            this.Controls.Add(this.checkMarcarMateria);
            this.Controls.Add(this.checkMarcarDisciplina);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnSortearQuestoes);
            this.Controls.Add(this.txtQtdQuestoes);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMaterias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxProvaRecuperacao);
            this.Controls.Add(this.cmbDisciplinas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TelaCadastroTesteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Testes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.CheckBox checkBoxProvaRecuperacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker txtData;
        private System.Windows.Forms.TextBox txtQtdQuestoes;
        private System.Windows.Forms.Button btnSortearQuestoes;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkMarcarDisciplina;
        private System.Windows.Forms.CheckBox checkMarcarMateria;
        private System.Windows.Forms.ListBox listQuestoes;
    }
}