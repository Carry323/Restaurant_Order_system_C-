namespace ExerciceRestoComposants
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTheCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addALineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateALineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteALineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tdcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(125, 60);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(213, 120);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsToolStripMenuItem,
            this.componentsToolStripMenuItem,
            this.tdcToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(711, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTheCommandsToolStripMenuItem,
            this.toolStripSeparator1,
            this.addALineToolStripMenuItem,
            this.updateALineToolStripMenuItem,
            this.deleteALineToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // showTheCommandsToolStripMenuItem
            // 
            this.showTheCommandsToolStripMenuItem.Name = "showTheCommandsToolStripMenuItem";
            this.showTheCommandsToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.showTheCommandsToolStripMenuItem.Text = "Show the commands";
            this.showTheCommandsToolStripMenuItem.Click += new System.EventHandler(this.showTheCommandsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // addALineToolStripMenuItem
            // 
            this.addALineToolStripMenuItem.Name = "addALineToolStripMenuItem";
            this.addALineToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.addALineToolStripMenuItem.Text = "Add a line";
            this.addALineToolStripMenuItem.Click += new System.EventHandler(this.addALineToolStripMenuItem_Click);
            // 
            // updateALineToolStripMenuItem
            // 
            this.updateALineToolStripMenuItem.Name = "updateALineToolStripMenuItem";
            this.updateALineToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.updateALineToolStripMenuItem.Text = "Update a line";
            this.updateALineToolStripMenuItem.Click += new System.EventHandler(this.updateALineToolStripMenuItem_Click);
            // 
            // deleteALineToolStripMenuItem
            // 
            this.deleteALineToolStripMenuItem.Name = "deleteALineToolStripMenuItem";
            this.deleteALineToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.deleteALineToolStripMenuItem.Text = "Delete a line ";
            this.deleteALineToolStripMenuItem.Click += new System.EventHandler(this.deleteALineToolStripMenuItem_Click);
            // 
            // componentsToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            this.componentsToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.componentsToolStripMenuItem.Text = "Components";
            this.componentsToolStripMenuItem.Click += new System.EventHandler(this.componentsToolStripMenuItem_Click);
            // 
            // tdcToolStripMenuItem
            // 
            this.tdcToolStripMenuItem.Name = "tdcToolStripMenuItem";
            this.tdcToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.tdcToolStripMenuItem.Text = "tdc";
            this.tdcToolStripMenuItem.Click += new System.EventHandler(this.tdcToolStripMenuItem_Click);
            // 
            // bindingSource2
            // 
            this.bindingSource2.CurrentChanged += new System.EventHandler(this.bindingSource2_CurrentChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Resto";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTheCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addALineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateALineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteALineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tdcToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}

