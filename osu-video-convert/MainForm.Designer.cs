
namespace osu_video_convert
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.osuRootPathLabel = new System.Windows.Forms.Label();
            this.osuPathTB = new System.Windows.Forms.TextBox();
            this.BrowserBtn = new System.Windows.Forms.Button();
            this.readDefaultBtn = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RunningLogLabel = new System.Windows.Forms.Label();
            this.fixAllBtn = new System.Windows.Forms.Button();
            this.languageLabel = new System.Windows.Forms.Label();
            this.languageCB = new System.Windows.Forms.ComboBox();
            this.HintLabel = new System.Windows.Forms.Label();
            this.LogRTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // osuRootPathLabel
            // 
            this.osuRootPathLabel.Location = new System.Drawing.Point(12, 9);
            this.osuRootPathLabel.Name = "osuRootPathLabel";
            this.osuRootPathLabel.Size = new System.Drawing.Size(94, 23);
            this.osuRootPathLabel.TabIndex = 0;
            this.osuRootPathLabel.Text = "osu根目录";
            this.osuRootPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // osuPathTB
            // 
            this.osuPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.osuPathTB.Location = new System.Drawing.Point(112, 11);
            this.osuPathTB.Name = "osuPathTB";
            this.osuPathTB.ReadOnly = true;
            this.osuPathTB.Size = new System.Drawing.Size(534, 21);
            this.osuPathTB.TabIndex = 1;
            this.osuPathTB.TextChanged += new System.EventHandler(this.osuPathTB_TextChanged);
            // 
            // BrowserBtn
            // 
            this.BrowserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowserBtn.Location = new System.Drawing.Point(652, 9);
            this.BrowserBtn.Name = "BrowserBtn";
            this.BrowserBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowserBtn.TabIndex = 3;
            this.BrowserBtn.Text = "浏览";
            this.BrowserBtn.UseVisualStyleBackColor = true;
            this.BrowserBtn.Click += new System.EventHandler(this.BrowserBtn_Click);
            // 
            // readDefaultBtn
            // 
            this.readDefaultBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readDefaultBtn.Location = new System.Drawing.Point(736, 9);
            this.readDefaultBtn.Name = "readDefaultBtn";
            this.readDefaultBtn.Size = new System.Drawing.Size(177, 23);
            this.readDefaultBtn.TabIndex = 4;
            this.readDefaultBtn.Text = "自动获取路径";
            this.readDefaultBtn.UseVisualStyleBackColor = true;
            this.readDefaultBtn.Click += new System.EventHandler(this.readDefaultBtn_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "双击恢复窗口 osu!stable 视频格式修复(mp42flv)";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // RunningLogLabel
            // 
            this.RunningLogLabel.Location = new System.Drawing.Point(12, 71);
            this.RunningLogLabel.Name = "RunningLogLabel";
            this.RunningLogLabel.Size = new System.Drawing.Size(221, 23);
            this.RunningLogLabel.TabIndex = 6;
            this.RunningLogLabel.Text = "运行日志";
            this.RunningLogLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fixAllBtn
            // 
            this.fixAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fixAllBtn.Location = new System.Drawing.Point(736, 68);
            this.fixAllBtn.Name = "fixAllBtn";
            this.fixAllBtn.Size = new System.Drawing.Size(177, 23);
            this.fixAllBtn.TabIndex = 7;
            this.fixAllBtn.Text = "修复本地所有视频";
            this.fixAllBtn.UseVisualStyleBackColor = true;
            this.fixAllBtn.Click += new System.EventHandler(this.fixAll_Click);
            // 
            // languageLabel
            // 
            this.languageLabel.Location = new System.Drawing.Point(13, 36);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(93, 23);
            this.languageLabel.TabIndex = 8;
            this.languageLabel.Text = "语言";
            this.languageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // languageCB
            // 
            this.languageCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCB.FormattingEnabled = true;
            this.languageCB.Items.AddRange(new object[] {
            "English",
            "中文"});
            this.languageCB.Location = new System.Drawing.Point(112, 39);
            this.languageCB.Name = "languageCB";
            this.languageCB.Size = new System.Drawing.Size(121, 20);
            this.languageCB.TabIndex = 9;
            this.languageCB.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // HintLabel
            // 
            this.HintLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.HintLabel.Location = new System.Drawing.Point(239, 39);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(488, 52);
            this.HintLabel.TabIndex = 10;
            this.HintLabel.Text = "*最小化本程序可实时监控新图并转换";
            this.HintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogRTB
            // 
            this.LogRTB.BackColor = System.Drawing.Color.White;
            this.LogRTB.Location = new System.Drawing.Point(15, 97);
            this.LogRTB.Name = "LogRTB";
            this.LogRTB.ReadOnly = true;
            this.LogRTB.Size = new System.Drawing.Size(898, 339);
            this.LogRTB.TabIndex = 11;
            this.LogRTB.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 448);
            this.Controls.Add(this.LogRTB);
            this.Controls.Add(this.HintLabel);
            this.Controls.Add(this.languageCB);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.fixAllBtn);
            this.Controls.Add(this.RunningLogLabel);
            this.Controls.Add(this.readDefaultBtn);
            this.Controls.Add(this.BrowserBtn);
            this.Controls.Add(this.osuPathTB);
            this.Controls.Add(this.osuRootPathLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "osu!stable 视频格式修复(mp42flv)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label osuRootPathLabel;
        private System.Windows.Forms.TextBox osuPathTB;
        private System.Windows.Forms.Button BrowserBtn;
        private System.Windows.Forms.Button readDefaultBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label RunningLogLabel;
        private System.Windows.Forms.Button fixAllBtn;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.ComboBox languageCB;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.RichTextBox LogRTB;
    }
}

