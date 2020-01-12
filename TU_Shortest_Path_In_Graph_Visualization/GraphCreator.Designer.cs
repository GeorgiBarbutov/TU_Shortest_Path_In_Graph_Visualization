namespace TU_Shortest_Path_In_Graph_Visualization
{
    partial class GraphCreator
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
            this.AddNodeButton = new System.Windows.Forms.Button();
            this.AddLinkButton = new System.Windows.Forms.Button();
            this.RemoveNodeButton = new System.Windows.Forms.Button();
            this.RemoveLinkButton = new System.Windows.Forms.Button();
            this.EditLinkButton = new System.Windows.Forms.Button();
            this.LoadGraphButton = new System.Windows.Forms.Button();
            this.SaveGraphButton = new System.Windows.Forms.Button();
            this.SimulateAlgorithmButton = new System.Windows.Forms.Button();
            this.Node1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Node2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.NodesLabel = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.Visualization = new System.Windows.Forms.PictureBox();
            this.GenerateRandomButton = new System.Windows.Forms.Button();
            this.RandomLinksUpDown = new System.Windows.Forms.NumericUpDown();
            this.RandomLinksLabel = new System.Windows.Forms.Label();
            this.RandomNodesLabel = new System.Windows.Forms.Label();
            this.RandomNodesUpDown = new System.Windows.Forms.NumericUpDown();
            this.SetSourceButton = new System.Windows.Forms.Button();
            this.SetDestinationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Node1NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node2NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Visualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomLinksUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomNodesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // AddNodeButton
            // 
            this.AddNodeButton.Location = new System.Drawing.Point(12, 533);
            this.AddNodeButton.Name = "AddNodeButton";
            this.AddNodeButton.Size = new System.Drawing.Size(130, 59);
            this.AddNodeButton.TabIndex = 1;
            this.AddNodeButton.Text = "Add Node";
            this.AddNodeButton.UseVisualStyleBackColor = true;
            this.AddNodeButton.Click += new System.EventHandler(this.AddNodeButton_Click);
            // 
            // AddLinkButton
            // 
            this.AddLinkButton.Location = new System.Drawing.Point(380, 533);
            this.AddLinkButton.Name = "AddLinkButton";
            this.AddLinkButton.Size = new System.Drawing.Size(130, 59);
            this.AddLinkButton.TabIndex = 2;
            this.AddLinkButton.Text = "Add Link";
            this.AddLinkButton.UseVisualStyleBackColor = true;
            this.AddLinkButton.Click += new System.EventHandler(this.AddLinkButton_Click);
            // 
            // RemoveNodeButton
            // 
            this.RemoveNodeButton.Location = new System.Drawing.Point(12, 628);
            this.RemoveNodeButton.Name = "RemoveNodeButton";
            this.RemoveNodeButton.Size = new System.Drawing.Size(130, 59);
            this.RemoveNodeButton.TabIndex = 3;
            this.RemoveNodeButton.Text = "Remove Node";
            this.RemoveNodeButton.UseVisualStyleBackColor = true;
            this.RemoveNodeButton.Click += new System.EventHandler(this.RemoveNodeButton_Click);
            // 
            // RemoveLinkButton
            // 
            this.RemoveLinkButton.Location = new System.Drawing.Point(380, 627);
            this.RemoveLinkButton.Name = "RemoveLinkButton";
            this.RemoveLinkButton.Size = new System.Drawing.Size(132, 59);
            this.RemoveLinkButton.TabIndex = 4;
            this.RemoveLinkButton.Text = "Remove Link";
            this.RemoveLinkButton.UseVisualStyleBackColor = true;
            this.RemoveLinkButton.Click += new System.EventHandler(this.RemoveLinkButton_Click);
            // 
            // EditLinkButton
            // 
            this.EditLinkButton.Location = new System.Drawing.Point(528, 533);
            this.EditLinkButton.Name = "EditLinkButton";
            this.EditLinkButton.Size = new System.Drawing.Size(132, 59);
            this.EditLinkButton.TabIndex = 5;
            this.EditLinkButton.Text = "Edit Link";
            this.EditLinkButton.UseVisualStyleBackColor = true;
            this.EditLinkButton.Click += new System.EventHandler(this.EditLinkButton_Click);
            // 
            // LoadGraphButton
            // 
            this.LoadGraphButton.Location = new System.Drawing.Point(1118, 627);
            this.LoadGraphButton.Name = "LoadGraphButton";
            this.LoadGraphButton.Size = new System.Drawing.Size(132, 59);
            this.LoadGraphButton.TabIndex = 6;
            this.LoadGraphButton.Text = "Load Graph";
            this.LoadGraphButton.UseVisualStyleBackColor = true;
            this.LoadGraphButton.Click += new System.EventHandler(this.LoadGraphButton_Click);
            // 
            // SaveGraphButton
            // 
            this.SaveGraphButton.Location = new System.Drawing.Point(1118, 533);
            this.SaveGraphButton.Name = "SaveGraphButton";
            this.SaveGraphButton.Size = new System.Drawing.Size(132, 59);
            this.SaveGraphButton.TabIndex = 7;
            this.SaveGraphButton.Text = "Save Graph";
            this.SaveGraphButton.UseVisualStyleBackColor = true;
            this.SaveGraphButton.Click += new System.EventHandler(this.SaveGraphButton_Click);
            // 
            // SimulateAlgorithmButton
            // 
            this.SimulateAlgorithmButton.Location = new System.Drawing.Point(843, 533);
            this.SimulateAlgorithmButton.Name = "SimulateAlgorithmButton";
            this.SimulateAlgorithmButton.Size = new System.Drawing.Size(132, 59);
            this.SimulateAlgorithmButton.TabIndex = 8;
            this.SimulateAlgorithmButton.Text = "Simulate Algorithm";
            this.SimulateAlgorithmButton.UseVisualStyleBackColor = true;
            this.SimulateAlgorithmButton.Click += new System.EventHandler(this.SimulateAlgorithmButton_Click);
            // 
            // Node1NumericUpDown
            // 
            this.Node1NumericUpDown.Location = new System.Drawing.Point(604, 632);
            this.Node1NumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Node1NumericUpDown.Name = "Node1NumericUpDown";
            this.Node1NumericUpDown.Size = new System.Drawing.Size(61, 22);
            this.Node1NumericUpDown.TabIndex = 9;
            // 
            // Node2NumericUpDown
            // 
            this.Node2NumericUpDown.Location = new System.Drawing.Point(604, 664);
            this.Node2NumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Node2NumericUpDown.Name = "Node2NumericUpDown";
            this.Node2NumericUpDown.Size = new System.Drawing.Size(61, 22);
            this.Node2NumericUpDown.TabIndex = 10;
            // 
            // WeightNumericUpDown
            // 
            this.WeightNumericUpDown.Location = new System.Drawing.Point(528, 664);
            this.WeightNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.WeightNumericUpDown.Name = "WeightNumericUpDown";
            this.WeightNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.WeightNumericUpDown.TabIndex = 11;
            // 
            // NodesLabel
            // 
            this.NodesLabel.AutoSize = true;
            this.NodesLabel.Location = new System.Drawing.Point(601, 612);
            this.NodesLabel.Name = "NodesLabel";
            this.NodesLabel.Size = new System.Drawing.Size(49, 17);
            this.NodesLabel.TabIndex = 12;
            this.NodesLabel.Text = "Nodes";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(525, 644);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(52, 17);
            this.WeightLabel.TabIndex = 13;
            this.WeightLabel.Text = "Weight";
            // 
            // Visualization
            // 
            this.Visualization.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Visualization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Visualization.Location = new System.Drawing.Point(12, 12);
            this.Visualization.Name = "Visualization";
            this.Visualization.Size = new System.Drawing.Size(1238, 472);
            this.Visualization.TabIndex = 15;
            this.Visualization.TabStop = false;
            this.Visualization.Paint += new System.Windows.Forms.PaintEventHandler(this.Visualization_Paint);
            this.Visualization.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Visualization_MouseDown);
            this.Visualization.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Visualization_MouseMove);
            this.Visualization.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Visualization_MouseUp);
            // 
            // GenerateRandomButton
            // 
            this.GenerateRandomButton.Location = new System.Drawing.Point(765, 628);
            this.GenerateRandomButton.Name = "GenerateRandomButton";
            this.GenerateRandomButton.Size = new System.Drawing.Size(132, 59);
            this.GenerateRandomButton.TabIndex = 16;
            this.GenerateRandomButton.Text = "Generate Random Graph";
            this.GenerateRandomButton.UseVisualStyleBackColor = true;
            this.GenerateRandomButton.Click += new System.EventHandler(this.GenerateRandomButton_Click);
            // 
            // RandomLinksUpDown
            // 
            this.RandomLinksUpDown.Location = new System.Drawing.Point(967, 665);
            this.RandomLinksUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.RandomLinksUpDown.Name = "RandomLinksUpDown";
            this.RandomLinksUpDown.Size = new System.Drawing.Size(61, 22);
            this.RandomLinksUpDown.TabIndex = 17;
            // 
            // RandomLinksLabel
            // 
            this.RandomLinksLabel.AutoSize = true;
            this.RandomLinksLabel.Location = new System.Drawing.Point(912, 664);
            this.RandomLinksLabel.Name = "RandomLinksLabel";
            this.RandomLinksLabel.Size = new System.Drawing.Size(41, 17);
            this.RandomLinksLabel.TabIndex = 18;
            this.RandomLinksLabel.Text = "Links";
            // 
            // RandomNodesLabel
            // 
            this.RandomNodesLabel.AutoSize = true;
            this.RandomNodesLabel.Location = new System.Drawing.Point(912, 634);
            this.RandomNodesLabel.Name = "RandomNodesLabel";
            this.RandomNodesLabel.Size = new System.Drawing.Size(49, 17);
            this.RandomNodesLabel.TabIndex = 19;
            this.RandomNodesLabel.Text = "Nodes";
            // 
            // RandomNodesUpDown
            // 
            this.RandomNodesUpDown.Location = new System.Drawing.Point(967, 634);
            this.RandomNodesUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.RandomNodesUpDown.Name = "RandomNodesUpDown";
            this.RandomNodesUpDown.Size = new System.Drawing.Size(61, 22);
            this.RandomNodesUpDown.TabIndex = 20;
            this.RandomNodesUpDown.Tag = "RandomNodes";
            this.RandomNodesUpDown.ValueChanged += new System.EventHandler(this.RandomNodesUpDown_ValueChanged);
            // 
            // SetSourceButton
            // 
            this.SetSourceButton.ForeColor = System.Drawing.Color.Blue;
            this.SetSourceButton.Location = new System.Drawing.Point(160, 533);
            this.SetSourceButton.Name = "SetSourceButton";
            this.SetSourceButton.Size = new System.Drawing.Size(130, 59);
            this.SetSourceButton.TabIndex = 21;
            this.SetSourceButton.Text = "Set as Source";
            this.SetSourceButton.UseVisualStyleBackColor = true;
            this.SetSourceButton.Click += new System.EventHandler(this.SetSourceButton_Click);
            // 
            // SetDestinationButton
            // 
            this.SetDestinationButton.ForeColor = System.Drawing.Color.Green;
            this.SetDestinationButton.Location = new System.Drawing.Point(160, 628);
            this.SetDestinationButton.Name = "SetDestinationButton";
            this.SetDestinationButton.Size = new System.Drawing.Size(130, 59);
            this.SetDestinationButton.TabIndex = 22;
            this.SetDestinationButton.Text = "Set as Destination";
            this.SetDestinationButton.UseVisualStyleBackColor = true;
            this.SetDestinationButton.Click += new System.EventHandler(this.SetDestinationButton_Click);
            // 
            // GraphCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 746);
            this.Controls.Add(this.SetDestinationButton);
            this.Controls.Add(this.SetSourceButton);
            this.Controls.Add(this.RandomNodesUpDown);
            this.Controls.Add(this.RandomNodesLabel);
            this.Controls.Add(this.RandomLinksLabel);
            this.Controls.Add(this.RandomLinksUpDown);
            this.Controls.Add(this.GenerateRandomButton);
            this.Controls.Add(this.Visualization);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.NodesLabel);
            this.Controls.Add(this.WeightNumericUpDown);
            this.Controls.Add(this.Node2NumericUpDown);
            this.Controls.Add(this.Node1NumericUpDown);
            this.Controls.Add(this.SimulateAlgorithmButton);
            this.Controls.Add(this.SaveGraphButton);
            this.Controls.Add(this.LoadGraphButton);
            this.Controls.Add(this.EditLinkButton);
            this.Controls.Add(this.RemoveLinkButton);
            this.Controls.Add(this.RemoveNodeButton);
            this.Controls.Add(this.AddLinkButton);
            this.Controls.Add(this.AddNodeButton);
            this.Name = "GraphCreator";
            this.Text = "Graph Creator";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Visualization_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Visualization_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Visualization_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.Node1NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node2NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Visualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomLinksUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomNodesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddNodeButton;
        private System.Windows.Forms.Button AddLinkButton;
        private System.Windows.Forms.Button RemoveNodeButton;
        private System.Windows.Forms.Button RemoveLinkButton;
        private System.Windows.Forms.Button EditLinkButton;
        private System.Windows.Forms.Button LoadGraphButton;
        private System.Windows.Forms.Button SaveGraphButton;
        private System.Windows.Forms.Button SimulateAlgorithmButton;
        private System.Windows.Forms.NumericUpDown Node1NumericUpDown;
        private System.Windows.Forms.NumericUpDown Node2NumericUpDown;
        private System.Windows.Forms.NumericUpDown WeightNumericUpDown;
        private System.Windows.Forms.Label NodesLabel;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.PictureBox Visualization;
        private System.Windows.Forms.Button GenerateRandomButton;
        private System.Windows.Forms.NumericUpDown RandomLinksUpDown;
        private System.Windows.Forms.Label RandomLinksLabel;
        private System.Windows.Forms.Label RandomNodesLabel;
        private System.Windows.Forms.NumericUpDown RandomNodesUpDown;
        private System.Windows.Forms.Button SetSourceButton;
        private System.Windows.Forms.Button SetDestinationButton;
    }
}

