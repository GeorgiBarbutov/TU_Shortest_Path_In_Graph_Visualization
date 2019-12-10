namespace TU_Shortest_Path_In_Graph_Visualization
{
    partial class DjikstraAlgorithm
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
            this.Visualization = new System.Windows.Forms.PictureBox();
            this.graphCreatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NextStepButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Visualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCreatorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Visualization
            // 
            this.Visualization.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Visualization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Visualization.Location = new System.Drawing.Point(12, 12);
            this.Visualization.Name = "Visualization";
            this.Visualization.Size = new System.Drawing.Size(1312, 472);
            this.Visualization.TabIndex = 16;
            this.Visualization.TabStop = false;
            // 
            // graphCreatorBindingSource
            // 
            this.graphCreatorBindingSource.DataSource = typeof(TU_Shortest_Path_In_Graph_Visualization.GraphCreator);
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(606, 595);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(132, 59);
            this.NextStepButton.TabIndex = 18;
            this.NextStepButton.Text = "Next Step";
            this.NextStepButton.UseVisualStyleBackColor = true;
            // 
            // DjikstraAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 746);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.Visualization);
            this.Name = "DjikstraAlgorithm";
            this.Text = "Djikstra Algorithm";
            ((System.ComponentModel.ISupportInitialize)(this.Visualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCreatorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Visualization;
        private System.Windows.Forms.BindingSource graphCreatorBindingSource;
        private System.Windows.Forms.Button NextStepButton;
    }
}