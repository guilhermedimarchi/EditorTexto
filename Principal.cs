using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Editor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmPrincipal : System.Windows.Forms.Form
	{
        private bool saveText;
        private Text Texto;
        private System.Windows.Forms.GroupBox gbTexto;
        private TextBox [] caixaTexto = null;
        private Panel pTexto;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPrincipal()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Texto = new Text();
            Texto.InsertLine("", -1);
            saveText = true;
            DrawText();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.gbTexto = new System.Windows.Forms.GroupBox();
            this.pTexto = new System.Windows.Forms.Panel();
            this.gbTexto.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTexto
            // 
            this.gbTexto.Controls.Add(this.pTexto);
            this.gbTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTexto.Location = new System.Drawing.Point(0, 0);
            this.gbTexto.Name = "gbTexto";
            this.gbTexto.Size = new System.Drawing.Size(384, 566);
            this.gbTexto.TabIndex = 4;
            this.gbTexto.TabStop = false;
            this.gbTexto.Text = "Texto:";
            // 
            // pTexto
            // 
            this.pTexto.AutoScroll = true;
            this.pTexto.AutoSize = true;
            this.pTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTexto.Location = new System.Drawing.Point(3, 18);
            this.pTexto.Name = "pTexto";
            this.pTexto.Size = new System.Drawing.Size(378, 545);
            this.pTexto.TabIndex = 0;
            this.pTexto.Paint += new System.Windows.Forms.PaintEventHandler(this.pTexto_Paint);
            // 
            // frmPrincipal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(384, 566);
            this.Controls.Add(this.gbTexto);
            this.Name = "frmPrincipal";
            this.Text = "Editor de Textos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbTexto.ResumeLayout(false);
            this.gbTexto.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmPrincipal());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		// Função responsável por atualizar o texto na tela
		private void DrawText()
		{
			caixaTexto = new TextBox[Texto.NumLines];
            
            Node n = Texto.FirstLine;
            int i=0;
            pTexto.Controls.Clear();
			while (n!=null)
			{
                caixaTexto[i] = new TextBox();
                caixaTexto[i].Text = Convert.ToString(n.Info);
                caixaTexto[i].Left = 20;
                caixaTexto[i].Top = 31 * i + 20;
                caixaTexto[i].Font = new Font("Arial", 18);
                caixaTexto[i].Width = 300;
                caixaTexto[i].BorderStyle = BorderStyle.None;
                caixaTexto[i].Tag = i.ToString();
                caixaTexto[i].KeyUp += txtTexto_KeyDown;
                caixaTexto[i].Leave += txtTexto_Leave;
                caixaTexto[i].PreviewKeyDown += txtTexto_PreviewKeyDown;
                
                pTexto.Controls.Add(caixaTexto[i]);

				n = n.Next;
                i++;
			}
		}

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox t = sender as TextBox;
            int pos = t.SelectionStart;
            int index = Convert.ToInt32(t.Tag);
            // Criando linha nova
            if (e.KeyCode == Keys.Enter)
            {
                string antes = t.Text.Substring(0, t.SelectionStart);
                string depois = t.Text.Substring(t.SelectionStart);
                t.Text = antes;
                Texto.InsertLine(depois, index);
                DrawText();
                caixaTexto[index + 1].Focus();
                caixaTexto[index + 1].SelectionStart = (pos-1>=0?pos-1:0);
                caixaTexto[index + 1].SelectionLength = 0;
            }
            if (e.KeyCode == Keys.Up)
            {
                index--;
                if (index < 0)
                    index = 0;
                caixaTexto[index].Focus();
                caixaTexto[index].SelectionStart = pos + 1;
                caixaTexto[index].SelectionLength = 0;
            }
            if (e.KeyCode == Keys.Down)
            {
                index++;
                if (index >= caixaTexto.Length)
                    index = caixaTexto.Length - 1;
                caixaTexto[index].Focus();
                caixaTexto[index].SelectionStart = (pos - 1 >= 0 ? pos - 1 : 0);
                caixaTexto[index].SelectionLength = 0;
            }
        }

        private void txtTexto_Leave(object sender, EventArgs e)
        {
            if (saveText)
            {
                TextBox t = sender as TextBox;
                int index = Convert.ToInt32(t.Tag);
                Texto.ChangeLine(t.Text, index);
            }
            else
            {
                saveText = true;
            }
        }

        private void txtTexto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TextBox t = sender as TextBox;
            int pos = t.SelectionStart;
            int index = Convert.ToInt32(t.Tag);
            if (e.KeyCode == Keys.Back)
            {
                if (pos == 0 && index > 0)
                {
                    Texto.ChangeLine(t.Text, index);
                    int sp = caixaTexto[index - 1].Text.Length;
                    saveText = false;
                    Texto.RemoveLine(index);
                    DrawText();
                    caixaTexto[index - 1].Focus();
                    caixaTexto[index - 1].SelectionStart = sp;
                    caixaTexto[index - 1].SelectionLength = 0;
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (pos == t.Text.Length && index < Texto.NumLines-1)
                {
                    Texto.ChangeLine(t.Text, index);
                    int sp = caixaTexto[index].Text.Length;
                    saveText = false;
                    Texto.DeleteLine(index);
                    DrawText();
                    caixaTexto[index].Focus();
                    caixaTexto[index].SelectionStart = sp;
                    caixaTexto[index].SelectionLength = 0;
                }
            }

        }

        private void pTexto_Paint(object sender, PaintEventArgs e)
        {

        }

	}
}
