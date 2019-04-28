namespace lottoForm
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_pilio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_pilio
            // 
            this.btn_pilio.Location = new System.Drawing.Point(12, 12);
            this.btn_pilio.Name = "btn_pilio";
            this.btn_pilio.Size = new System.Drawing.Size(268, 160);
            this.btn_pilio.TabIndex = 0;
            this.btn_pilio.Text = "透過 pilio 網站取得資料";
            this.btn_pilio.UseVisualStyleBackColor = true;
            this.btn_pilio.Click += new System.EventHandler(this.btn_pilio_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_pilio);
            this.Name = "FormMain";
            this.Text = "FormLottoCrawler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_pilio;
    }
}

