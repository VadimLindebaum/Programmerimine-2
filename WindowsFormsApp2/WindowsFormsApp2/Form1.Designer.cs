namespace WindowsFormsApp2
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridCars = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtMake = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCars)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(419, 246);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(284, 22);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "ID";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(419, 286);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(284, 22);
            this.txtYear.TabIndex = 1;
            this.txtYear.Text = "Brand";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(419, 331);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(283, 22);
            this.txtModel.TabIndex = 2;
            this.txtModel.Text = "Model";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(419, 386);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(524, 386);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(645, 386);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridCars
            // 
            this.dataGridCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCars.Location = new System.Drawing.Point(12, 27);
            this.dataGridCars.Name = "dataGridCars";
            this.dataGridCars.RowHeadersWidth = 51;
            this.dataGridCars.RowTemplate.Height = 24;
            this.dataGridCars.Size = new System.Drawing.Size(390, 267);
            this.dataGridCars.TabIndex = 6;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(524, 415);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(419, 206);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(283, 22);
            this.txtMake.TabIndex = 8;
            this.txtMake.Text = "Make";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMake);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dataGridCars);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtId);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridCars;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtMake;
    }
}

