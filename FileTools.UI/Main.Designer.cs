
namespace FileTools.UI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tarefas = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicados = new System.Windows.Forms.ToolStripMenuItem();
            this.mesclar = new System.Windows.Forms.ToolStripMenuItem();
            this.renomearTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.renomearGuid = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem2.Text = "Renomear Todos";
            // 
            // tarefas
            // 
            this.tarefas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicados,
            this.mesclar,
            this.renomearTodos,
            this.renomearGuid});
            this.tarefas.Name = "tarefas";
            this.tarefas.Size = new System.Drawing.Size(55, 20);
            this.tarefas.Text = "Tarefas";
            // 
            // duplicados
            // 
            this.duplicados.Name = "duplicados";
            this.duplicados.Size = new System.Drawing.Size(234, 22);
            this.duplicados.Text = "Encontrar arquivos duplicados";
            // 
            // mesclar
            // 
            this.mesclar.Name = "mesclar";
            this.mesclar.Size = new System.Drawing.Size(234, 22);
            this.mesclar.Text = "Mesclar Pastas";
            // 
            // renomearTodos
            // 
            this.renomearTodos.DoubleClickEnabled = true;
            this.renomearTodos.Name = "renomearTodos";
            this.renomearTodos.Size = new System.Drawing.Size(234, 22);
            this.renomearTodos.Text = "Renomear Todos";
            // 
            // renomearGuid
            // 
            this.renomearGuid.Name = "renomearGuid";
            this.renomearGuid.Size = new System.Drawing.Size(234, 22);
            this.renomearGuid.Text = "Renomear Todos (Guid)";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tarefas});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(234, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "File Tools";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tarefas;
        private System.Windows.Forms.ToolStripMenuItem duplicados;
        private System.Windows.Forms.ToolStripMenuItem mesclar;
        private System.Windows.Forms.ToolStripMenuItem renomearTodos;
        private System.Windows.Forms.ToolStripMenuItem renomearGuid;
        private System.Windows.Forms.MenuStrip menuStrip;
    }
}

