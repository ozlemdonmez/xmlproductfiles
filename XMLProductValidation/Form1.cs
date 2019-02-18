using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLProductValidation
{
    public partial class Form1 : Form
    {
        private TextBox PathTextbox;
        private TextBox ErrorLineTextbox;
        private Label filepath;
        private Label linenumber;
        private ListBox errorlines;
        private TextBox ProductTagTextbox;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button FindProducts;

        public Form1()
        {
            InitializeComponent();
        }

        

       

        private void InitializeComponent()
        {
            this.FindProducts = new System.Windows.Forms.Button();
            this.PathTextbox = new System.Windows.Forms.TextBox();
            this.ErrorLineTextbox = new System.Windows.Forms.TextBox();
            this.filepath = new System.Windows.Forms.Label();
            this.linenumber = new System.Windows.Forms.Label();
            this.errorlines = new System.Windows.Forms.ListBox();
            this.ProductTagTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FindProducts
            // 
            this.FindProducts.Location = new System.Drawing.Point(143, 145);
            this.FindProducts.Name = "FindProducts";
            this.FindProducts.Size = new System.Drawing.Size(91, 25);
            this.FindProducts.TabIndex = 0;
            this.FindProducts.Text = "Find Products";
            this.FindProducts.UseVisualStyleBackColor = true;
            this.FindProducts.Click += new System.EventHandler(this.FindProducts_Click);
            // 
            // PathTextbox
            // 
            this.PathTextbox.Location = new System.Drawing.Point(134, 55);
            this.PathTextbox.Name = "PathTextbox";
            this.PathTextbox.Size = new System.Drawing.Size(100, 20);
            this.PathTextbox.TabIndex = 1;
            // 
            // ErrorLineTextbox
            // 
            this.ErrorLineTextbox.Location = new System.Drawing.Point(134, 81);
            this.ErrorLineTextbox.Name = "ErrorLineTextbox";
            this.ErrorLineTextbox.Size = new System.Drawing.Size(100, 20);
            this.ErrorLineTextbox.TabIndex = 2;
            // 
            // filepath
            // 
            this.filepath.AutoSize = true;
            this.filepath.Location = new System.Drawing.Point(25, 58);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(88, 13);
            this.filepath.TabIndex = 3;
            this.filepath.Text = "Product File Path";
            // 
            // linenumber
            // 
            this.linenumber.AutoSize = true;
            this.linenumber.Location = new System.Drawing.Point(25, 88);
            this.linenumber.Name = "linenumber";
            this.linenumber.Size = new System.Drawing.Size(52, 13);
            this.linenumber.TabIndex = 4;
            this.linenumber.Text = "Error Line";
            // 
            // errorlines
            // 
            this.errorlines.FormattingEnabled = true;
            this.errorlines.Location = new System.Drawing.Point(347, 55);
            this.errorlines.Name = "errorlines";
            this.errorlines.Size = new System.Drawing.Size(150, 95);
            this.errorlines.TabIndex = 6;
            // 
            // ProductTagTextbox
            // 
            this.ProductTagTextbox.Location = new System.Drawing.Point(134, 107);
            this.ProductTagTextbox.Name = "ProductTagTextbox";
            this.ProductTagTextbox.Size = new System.Drawing.Size(100, 20);
            this.ProductTagTextbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Product Code Tag";
            // 
        
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(517, 243);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductTagTextbox);
            this.Controls.Add(this.errorlines);
            this.Controls.Add(this.linenumber);
            this.Controls.Add(this.filepath);
            this.Controls.Add(this.ErrorLineTextbox);
            this.Controls.Add(this.PathTextbox);
            this.Controls.Add(this.FindProducts);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FindProducts_Click(object sender, EventArgs e)
        {
            
            //XmlReader xmlReader = XmlReader.Create("C:/Downloads/boyner_product.xml");
            XmlDataDocument xmldoc=new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs=new FileStream(PathTextbox.Text, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName(ProductTagTextbox.Text);
            int errorproduct = int.Parse(ErrorLineTextbox.Text)-1;
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                if (i == errorproduct)
                {
                    string productcode= xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    errorlines.Items.Add(productcode);
                }
                
                
            }
        }

    }
}
