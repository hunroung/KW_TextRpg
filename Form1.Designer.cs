﻿namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.namebox = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namebox
            // 
            this.namebox.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.namebox.Location = new System.Drawing.Point(459, 208);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(109, 50);
            this.namebox.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(459, 291);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(109, 34);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "모험을 시작하기";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(459, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "불러오기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(459, 389);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "종료하기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1049, 616);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.namebox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

