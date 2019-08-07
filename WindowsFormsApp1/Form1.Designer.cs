namespace WindowsFormsApp1
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
            this.GetProductsIQueryableWithExceptionButton = new System.Windows.Forms.Button();
            this.GetProductsIQueryableWithoutExceptionButton = new System.Windows.Forms.Button();
            this.GetProductsToListWithoutExceptionButton = new System.Windows.Forms.Button();
            this.ImmediateExecutionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetProductsIQueryableWithExceptionButton
            // 
            this.GetProductsIQueryableWithExceptionButton.Location = new System.Drawing.Point(12, 12);
            this.GetProductsIQueryableWithExceptionButton.Name = "GetProductsIQueryableWithExceptionButton";
            this.GetProductsIQueryableWithExceptionButton.Size = new System.Drawing.Size(290, 23);
            this.GetProductsIQueryableWithExceptionButton.TabIndex = 0;
            this.GetProductsIQueryableWithExceptionButton.Text = "Get Products IQueryable - with exception";
            this.GetProductsIQueryableWithExceptionButton.UseVisualStyleBackColor = true;
            this.GetProductsIQueryableWithExceptionButton.Click += new System.EventHandler(this.GetProductsIQueryableWithExceptionButton_Click);
            // 
            // GetProductsIQueryableWithoutExceptionButton
            // 
            this.GetProductsIQueryableWithoutExceptionButton.Location = new System.Drawing.Point(12, 41);
            this.GetProductsIQueryableWithoutExceptionButton.Name = "GetProductsIQueryableWithoutExceptionButton";
            this.GetProductsIQueryableWithoutExceptionButton.Size = new System.Drawing.Size(290, 23);
            this.GetProductsIQueryableWithoutExceptionButton.TabIndex = 1;
            this.GetProductsIQueryableWithoutExceptionButton.Text = "Get Products IQueryable - without exception";
            this.GetProductsIQueryableWithoutExceptionButton.UseVisualStyleBackColor = true;
            this.GetProductsIQueryableWithoutExceptionButton.Click += new System.EventHandler(this.GetProductsIQueryableWithoutExceptionButton_Click);
            // 
            // GetProductsToListWithoutExceptionButton
            // 
            this.GetProductsToListWithoutExceptionButton.Location = new System.Drawing.Point(12, 70);
            this.GetProductsToListWithoutExceptionButton.Name = "GetProductsToListWithoutExceptionButton";
            this.GetProductsToListWithoutExceptionButton.Size = new System.Drawing.Size(290, 23);
            this.GetProductsToListWithoutExceptionButton.TabIndex = 2;
            this.GetProductsToListWithoutExceptionButton.Text = "Get Products .ToList - without exception";
            this.GetProductsToListWithoutExceptionButton.UseVisualStyleBackColor = true;
            this.GetProductsToListWithoutExceptionButton.Click += new System.EventHandler(this.GetProductsToListWithoutExceptionButton_Click);
            // 
            // ImmediateExecutionButton
            // 
            this.ImmediateExecutionButton.Location = new System.Drawing.Point(12, 109);
            this.ImmediateExecutionButton.Name = "ImmediateExecutionButton";
            this.ImmediateExecutionButton.Size = new System.Drawing.Size(290, 23);
            this.ImmediateExecutionButton.TabIndex = 3;
            this.ImmediateExecutionButton.Text = "Get count example";
            this.ImmediateExecutionButton.UseVisualStyleBackColor = true;
            this.ImmediateExecutionButton.Click += new System.EventHandler(this.ImmediateExecutionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 146);
            this.Controls.Add(this.ImmediateExecutionButton);
            this.Controls.Add(this.GetProductsToListWithoutExceptionButton);
            this.Controls.Add(this.GetProductsIQueryableWithoutExceptionButton);
            this.Controls.Add(this.GetProductsIQueryableWithExceptionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Returning data from Enity Framework code samples";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetProductsIQueryableWithExceptionButton;
        private System.Windows.Forms.Button GetProductsIQueryableWithoutExceptionButton;
        private System.Windows.Forms.Button GetProductsToListWithoutExceptionButton;
        private System.Windows.Forms.Button ImmediateExecutionButton;
    }
}

