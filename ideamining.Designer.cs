namespace ServiceRanking
{
    partial class ideamining
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ideamining));
            this.start = new System.Windows.Forms.Button();
            this.problem = new System.Windows.Forms.RichTextBox();
            this.solve = new System.Windows.Forms.RichTextBox();
            this.result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(552, 527);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.button1_Click);
            // 
            // problem
            // 
            this.problem.Location = new System.Drawing.Point(472, 30);
            this.problem.Name = "problem";
            this.problem.Size = new System.Drawing.Size(400, 450);
            this.problem.TabIndex = 1;
            this.problem.Text = resources.GetString("problem.Text");
            // 
            // solve
            // 
            this.solve.Location = new System.Drawing.Point(15, 30);
            this.solve.Name = "solve";
            this.solve.Size = new System.Drawing.Size(400, 450);
            this.solve.TabIndex = 2;
            this.solve.Text = resources.GetString("solve.Text");
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(25, 626);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 13);
            this.result.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 594);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Result :";
            // 
            // ideamining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 750);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.solve);
            this.Controls.Add(this.problem);
            this.Controls.Add(this.start);
            this.Name = "ideamining";
            this.Text = "ideamining";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.RichTextBox problem;
        private System.Windows.Forms.RichTextBox solve;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label label1;
    }
}