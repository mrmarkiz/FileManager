namespace FileManager
{
    partial class Form1
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
            label2 = new Label();
            label1 = new Label();
            labelPath = new Label();
            buttonBack = new Button();
            textBoxFilter = new TextBox();
            listBoxDrives = new ListBox();
            label3 = new Label();
            labelSelected = new Label();
            buttonDelete = new Button();
            buttonCopy = new Button();
            buttonPaste = new Button();
            buttonCut = new Button();
            labelBuffer = new Label();
            label5 = new Label();
            listBoxSelectedProperties = new ListBox();
            buttonProperties = new Button();
            label4 = new Label();
            buttonSortAsc = new Button();
            buttonSortDesc = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 15);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 9;
            label2.Text = "Current directory:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(787, 79);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 10;
            label1.Text = "Files filter:";
            // 
            // labelPath
            // 
            labelPath.AutoSize = true;
            labelPath.Location = new Point(377, 15);
            labelPath.Name = "labelPath";
            labelPath.Size = new Size(49, 20);
            labelPath.TabIndex = 8;
            labelPath.Text = "None!";
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(12, 10);
            buttonBack.Margin = new Padding(3, 4, 3, 4);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(217, 25);
            buttonBack.TabIndex = 7;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // textBoxFilter
            // 
            textBoxFilter.Location = new Point(746, 103);
            textBoxFilter.Margin = new Padding(3, 4, 3, 4);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(153, 27);
            textBoxFilter.TabIndex = 6;
            textBoxFilter.TextChanged += textBoxFilter_TextChanged;
            // 
            // listBoxDrives
            // 
            listBoxDrives.FormattingEnabled = true;
            listBoxDrives.HorizontalScrollbar = true;
            listBoxDrives.ItemHeight = 20;
            listBoxDrives.Location = new Point(12, 43);
            listBoxDrives.Margin = new Padding(3, 4, 3, 4);
            listBoxDrives.Name = "listBoxDrives";
            listBoxDrives.Size = new Size(217, 384);
            listBoxDrives.TabIndex = 5;
            listBoxDrives.SelectedIndexChanged += listBoxDrives_SelectedIndexChanged;
            listBoxDrives.DoubleClick += listBoxDrives_DoubleClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(248, 47);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 11;
            label3.Text = "Selected Item: ";
            // 
            // labelSelected
            // 
            labelSelected.AutoSize = true;
            labelSelected.Location = new Point(377, 47);
            labelSelected.Name = "labelSelected";
            labelSelected.Size = new Size(49, 20);
            labelSelected.TabIndex = 8;
            labelSelected.Text = "None!";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(248, 193);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(178, 42);
            buttonDelete.TabIndex = 12;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(248, 258);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(178, 42);
            buttonCopy.TabIndex = 12;
            buttonCopy.Text = "Copy";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // buttonPaste
            // 
            buttonPaste.Location = new Point(248, 385);
            buttonPaste.Name = "buttonPaste";
            buttonPaste.Size = new Size(178, 42);
            buttonPaste.TabIndex = 12;
            buttonPaste.Text = "Paste";
            buttonPaste.UseVisualStyleBackColor = true;
            buttonPaste.Click += buttonPaste_Click;
            // 
            // buttonCut
            // 
            buttonCut.Location = new Point(248, 322);
            buttonCut.Name = "buttonCut";
            buttonCut.Size = new Size(178, 42);
            buttonCut.TabIndex = 12;
            buttonCut.Text = "Cut";
            buttonCut.UseVisualStyleBackColor = true;
            buttonCut.Click += buttonCut_Click;
            // 
            // labelBuffer
            // 
            labelBuffer.AutoSize = true;
            labelBuffer.Location = new Point(377, 82);
            labelBuffer.Name = "labelBuffer";
            labelBuffer.Size = new Size(49, 20);
            labelBuffer.TabIndex = 8;
            labelBuffer.Text = "None!";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(248, 82);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 11;
            label5.Text = "File in buffer: ";
            // 
            // listBoxSelectedProperties
            // 
            listBoxSelectedProperties.FormattingEnabled = true;
            listBoxSelectedProperties.HorizontalScrollbar = true;
            listBoxSelectedProperties.ItemHeight = 20;
            listBoxSelectedProperties.Location = new Point(456, 82);
            listBoxSelectedProperties.Name = "listBoxSelectedProperties";
            listBoxSelectedProperties.Size = new Size(284, 344);
            listBoxSelectedProperties.TabIndex = 13;
            // 
            // buttonProperties
            // 
            buttonProperties.Location = new Point(248, 130);
            buttonProperties.Name = "buttonProperties";
            buttonProperties.Size = new Size(178, 42);
            buttonProperties.TabIndex = 12;
            buttonProperties.Text = "Properties";
            buttonProperties.UseVisualStyleBackColor = true;
            buttonProperties.Click += buttonProperties_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(558, 59);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 10;
            label4.Text = "Properties:";
            // 
            // buttonSortAsc
            // 
            buttonSortAsc.Location = new Point(746, 167);
            buttonSortAsc.Name = "buttonSortAsc";
            buttonSortAsc.Size = new Size(149, 40);
            buttonSortAsc.TabIndex = 14;
            buttonSortAsc.Tag = "asc";
            buttonSortAsc.Text = "Sort Asc";
            buttonSortAsc.UseVisualStyleBackColor = true;
            buttonSortAsc.Click += buttonSort_Click;
            // 
            // buttonSortDesc
            // 
            buttonSortDesc.Location = new Point(746, 241);
            buttonSortDesc.Name = "buttonSortDesc";
            buttonSortDesc.Size = new Size(149, 40);
            buttonSortDesc.TabIndex = 14;
            buttonSortDesc.Tag = "desc";
            buttonSortDesc.Text = "Sort Desc";
            buttonSortDesc.UseVisualStyleBackColor = true;
            buttonSortDesc.Click += buttonSort_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 450);
            Controls.Add(buttonSortDesc);
            Controls.Add(buttonSortAsc);
            Controls.Add(listBoxSelectedProperties);
            Controls.Add(buttonCut);
            Controls.Add(buttonPaste);
            Controls.Add(buttonCopy);
            Controls.Add(buttonProperties);
            Controls.Add(buttonDelete);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labelBuffer);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(labelSelected);
            Controls.Add(labelPath);
            Controls.Add(buttonBack);
            Controls.Add(textBoxFilter);
            Controls.Add(listBoxDrives);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Label labelPath;
        private Button buttonBack;
        private TextBox textBoxFilter;
        private ListBox listBoxDrives;
        private Label label3;
        private Label labelSelected;
        private Button buttonDelete;
        private Button buttonCopy;
        private Button buttonPaste;
        private Button buttonCut;
        private Label labelBuffer;
        private Label label5;
        private ListBox listBoxSelectedProperties;
        private Button buttonProperties;
        private Label label4;
        private Button buttonSortAsc;
        private Button buttonSortDesc;
    }
}