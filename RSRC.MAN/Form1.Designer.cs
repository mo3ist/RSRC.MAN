namespace RSRC.MAN
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
            this.create_resource = new System.Windows.Forms.Button();
            this.create_process = new System.Windows.Forms.Button();
            this.display_data = new System.Windows.Forms.Button();
            this.terminate_process = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // create_resource
            // 
            this.create_resource.Location = new System.Drawing.Point(168, 151);
            this.create_resource.Name = "create_resource";
            this.create_resource.Size = new System.Drawing.Size(139, 48);
            this.create_resource.TabIndex = 0;
            this.create_resource.Text = "Create Resource";
            this.create_resource.UseVisualStyleBackColor = true;
            this.create_resource.Click += new System.EventHandler(this.create_resource_Click);
            // 
            // create_process
            // 
            this.create_process.Location = new System.Drawing.Point(324, 151);
            this.create_process.Name = "create_process";
            this.create_process.Size = new System.Drawing.Size(139, 48);
            this.create_process.TabIndex = 1;
            this.create_process.Text = "Create Process";
            this.create_process.UseVisualStyleBackColor = true;
            this.create_process.Click += new System.EventHandler(this.button1_Click);
            // 
            // display_data
            // 
            this.display_data.Location = new System.Drawing.Point(168, 214);
            this.display_data.Name = "display_data";
            this.display_data.Size = new System.Drawing.Size(446, 57);
            this.display_data.TabIndex = 2;
            this.display_data.Text = "Display Data";
            this.display_data.UseVisualStyleBackColor = true;
            this.display_data.Click += new System.EventHandler(this.display_data_Click);
            // 
            // terminate_process
            // 
            this.terminate_process.Location = new System.Drawing.Point(469, 151);
            this.terminate_process.Name = "terminate_process";
            this.terminate_process.Size = new System.Drawing.Size(145, 48);
            this.terminate_process.TabIndex = 3;
            this.terminate_process.Text = "Terminate Process";
            this.terminate_process.UseVisualStyleBackColor = true;
            this.terminate_process.Click += new System.EventHandler(this.terminate_process_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.terminate_process);
            this.Controls.Add(this.display_data);
            this.Controls.Add(this.create_process);
            this.Controls.Add(this.create_resource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button create_resource;
        private System.Windows.Forms.Button create_process;
        private System.Windows.Forms.Button display_data;
        private System.Windows.Forms.Button terminate_process;
    }
}

