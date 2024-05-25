
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
            this.label1 = new System.Windows.Forms.Label();
            this.osuPathTB = new System.Windows.Forms.TextBox();
            this.BrowserBtn = new System.Windows.Forms.Button();
            this.readDefaultBtn = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.logTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fixAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "osu根目录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // osuPathTB
            // 
            this.osuPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.osuPathTB.Location = new System.Drawing.Point(80, 11);
            this.osuPathTB.Name = "osuPathTB";
            this.osuPathTB.ReadOnly = true;
            this.osuPathTB.Size = new System.Drawing.Size(650, 21);
            this.osuPathTB.TabIndex = 1;
            this.osuPathTB.TextChanged += new System.EventHandler(this.osuPathTB_TextChanged);
            // 
            // BrowserBtn
            // 
            this.BrowserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowserBtn.Location = new System.Drawing.Point(736, 9);
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
            this.readDefaultBtn.Location = new System.Drawing.Point(817, 9);
            this.readDefaultBtn.Name = "readDefaultBtn";
            this.readDefaultBtn.Size = new System.Drawing.Size(96, 23);
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
            // logTB
            // 
            this.logTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTB.Location = new System.Drawing.Point(12, 97);
            this.logTB.Multiline = true;
            this.logTB.Name = "logTB";
            this.logTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTB.Size = new System.Drawing.Size(901, 341);
            this.logTB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "运行日志";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fixAll
            // 
            this.fixAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fixAll.Location = new System.Drawing.Point(794, 68);
            this.fixAll.Name = "fixAll";
            this.fixAll.Size = new System.Drawing.Size(119, 23);
            this.fixAll.TabIndex = 7;
            this.fixAll.Text = "修复本地所有视频";
            this.fixAll.UseVisualStyleBackColor = true;
            this.fixAll.Click += new System.EventHandler(this.fixAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 450);
            this.Controls.Add(this.fixAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logTB);
            this.Controls.Add(this.readDefaultBtn);
            this.Controls.Add(this.BrowserBtn);
            this.Controls.Add(this.osuPathTB);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox osuPathTB;
        private System.Windows.Forms.Button BrowserBtn;
        private System.Windows.Forms.Button readDefaultBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox logTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fixAll;
    }
}

