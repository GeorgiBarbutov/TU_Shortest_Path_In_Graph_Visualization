namespace TU_Shortest_Path_In_Graph_Visualization
{
    partial class DijkstraAlgorithm
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
            this.NextStepButton = new System.Windows.Forms.Button();
            this.StepsLabel = new System.Windows.Forms.Label();
            this.UnvisitedLabel = new System.Windows.Forms.Label();
            this.VisitedLabel = new System.Windows.Forms.Label();
            this.LegendLabel = new System.Windows.Forms.Label();
            this.GoBackButton = new System.Windows.Forms.Button();
            this.ShortestPathLabel = new System.Windows.Forms.Label();
            this.CurrentNodeLabel = new System.Windows.Forms.Label();
            this.graphCreatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.Visualization.Size = new System.Drawing.Size(1238, 472);
            this.Visualization.TabIndex = 16;
            this.Visualization.TabStop = false;
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(474, 561);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(132, 59);
            this.NextStepButton.TabIndex = 18;
            this.NextStepButton.Text = "Next Step";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.NextStepButton_Click);
            // 
            // StepsLabel
            // 
            this.StepsLabel.AutoSize = true;
            this.StepsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.StepsLabel.Location = new System.Drawing.Point(15, 497);
            this.StepsLabel.Name = "StepsLabel";
            this.StepsLabel.Size = new System.Drawing.Size(58, 18);
            this.StepsLabel.TabIndex = 19;
            this.StepsLabel.Text = "Step 0: ";
            // 
            // UnvisitedLabel
            // 
            this.UnvisitedLabel.AutoSize = true;
            this.UnvisitedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UnvisitedLabel.Location = new System.Drawing.Point(14, 706);
            this.UnvisitedLabel.Name = "UnvisitedLabel";
            this.UnvisitedLabel.Size = new System.Drawing.Size(83, 20);
            this.UnvisitedLabel.TabIndex = 20;
            this.UnvisitedLabel.Text = "Unvisited:";
            // 
            // VisitedLabel
            // 
            this.VisitedLabel.AutoSize = true;
            this.VisitedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.VisitedLabel.Location = new System.Drawing.Point(14, 667);
            this.VisitedLabel.Name = "VisitedLabel";
            this.VisitedLabel.Size = new System.Drawing.Size(95, 20);
            this.VisitedLabel.TabIndex = 21;
            this.VisitedLabel.Text = "Visited: [   ]";
            // 
            // LegendLabel
            // 
            this.LegendLabel.AutoSize = true;
            this.LegendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LegendLabel.Location = new System.Drawing.Point(893, 497);
            this.LegendLabel.Name = "LegendLabel";
            this.LegendLabel.Size = new System.Drawing.Size(60, 18);
            this.LegendLabel.TabIndex = 22;
            this.LegendLabel.Text = "Legend:";
            // 
            // GoBackButton
            // 
            this.GoBackButton.Location = new System.Drawing.Point(612, 561);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(132, 59);
            this.GoBackButton.TabIndex = 23;
            this.GoBackButton.Text = "Go Back";
            this.GoBackButton.UseVisualStyleBackColor = true;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // ShortestPathLabel
            // 
            this.ShortestPathLabel.AutoSize = true;
            this.ShortestPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ShortestPathLabel.Location = new System.Drawing.Point(14, 629);
            this.ShortestPathLabel.Name = "ShortestPathLabel";
            this.ShortestPathLabel.Size = new System.Drawing.Size(116, 20);
            this.ShortestPathLabel.TabIndex = 24;
            this.ShortestPathLabel.Text = "Shortest Path:";
            // 
            // CurrentNodeLabel
            // 
            this.CurrentNodeLabel.AutoSize = true;
            this.CurrentNodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CurrentNodeLabel.Location = new System.Drawing.Point(14, 590);
            this.CurrentNodeLabel.Name = "CurrentNodeLabel";
            this.CurrentNodeLabel.Size = new System.Drawing.Size(119, 20);
            this.CurrentNodeLabel.TabIndex = 25;
            this.CurrentNodeLabel.Text = "Current Node: ";
            // 
            // graphCreatorBindingSource
            // 
            this.graphCreatorBindingSource.DataSource = typeof(TU_Shortest_Path_In_Graph_Visualization.GraphCreator);
            // 
            // DijkstraAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 746);
            this.Controls.Add(this.CurrentNodeLabel);
            this.Controls.Add(this.ShortestPathLabel);
            this.Controls.Add(this.GoBackButton);
            this.Controls.Add(this.LegendLabel);
            this.Controls.Add(this.VisitedLabel);
            this.Controls.Add(this.UnvisitedLabel);
            this.Controls.Add(this.StepsLabel);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.Visualization);
            this.Name = "DijkstraAlgorithm";
            this.Text = "Dijkstra Algorithm";
            this.Load += new System.EventHandler(this.DijkstraAlgorithm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Visualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCreatorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Visualization;
        private System.Windows.Forms.BindingSource graphCreatorBindingSource;
        private System.Windows.Forms.Button NextStepButton;
        private System.Windows.Forms.Label StepsLabel;
        private System.Windows.Forms.Label UnvisitedLabel;
        private System.Windows.Forms.Label VisitedLabel;
        private System.Windows.Forms.Label LegendLabel;
        private System.Windows.Forms.Button GoBackButton;
        private System.Windows.Forms.Label ShortestPathLabel;
        private System.Windows.Forms.Label CurrentNodeLabel;
    }
}