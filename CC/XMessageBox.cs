using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace CC
{
    public enum XMessageBoxIcon : int
    {
        None = 0,
        Information = 8,
        Question = 16,
        Warning = 32,
        Stop = 64,
        Error = 128
    }

    public partial class XMessageBox : Form
    {
        private PictureBox pctIcon;
        private Panel panel1;
        private Button btnOK;
        private Button btnCancel;
        private Button btnYes;
        private Button btnNo;
        private Button btnRetry;
        private Button btnAbort;
        private Button btnIgnore;
        private ImageList imageList1;
        private IContainer components;
        private Panel panelBtnContainer;
        private RichTextBox txtMessage;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMessageBox));
            this.pctIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelBtnContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelBtnContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctIcon
            // 
            this.pctIcon.Location = new System.Drawing.Point(11, 9);
            this.pctIcon.Name = "pctIcon";
            this.pctIcon.Size = new System.Drawing.Size(32, 32);
            this.pctIcon.TabIndex = 0;
            this.pctIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.pctIcon);
            this.panel1.Location = new System.Drawing.Point(11, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 75);
            this.panel1.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Location = new System.Drawing.Point(59, 3);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(300, 69);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "ซีรีส์หม่านโถวอึมครึม เธคอุเทนอาข่าอึมครึมอุปสงค์ ฮิตมอคคาดีมานด์ บึ้มเพนกวินเลกเ" +
    "ชอร์โทรพาสต้า";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(-14, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 27);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "ตกลง (&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(39, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ยกเลิก (&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(93, 9);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(74, 27);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "ใช่ (&Y)";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Visible = false;
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(144, 9);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(74, 27);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "ไม่ใช่ (&N)";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Visible = false;
            // 
            // btnRetry
            // 
            this.btnRetry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetry.Location = new System.Drawing.Point(194, 9);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(97, 27);
            this.btnRetry.TabIndex = 2;
            this.btnRetry.Text = "ลองอีกครั้ง (&R)";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Visible = false;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbort.Location = new System.Drawing.Point(301, 9);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(74, 27);
            this.btnAbort.TabIndex = 2;
            this.btnAbort.Text = "หยุด (&A)";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Visible = false;
            // 
            // btnIgnore
            // 
            this.btnIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnore.Location = new System.Drawing.Point(257, 9);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(74, 27);
            this.btnIgnore.TabIndex = 2;
            this.btnIgnore.Text = "ข้ามไป (&I)";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_error.png");
            this.imageList1.Images.SetKeyName(1, "icon_info.png");
            this.imageList1.Images.SetKeyName(2, "icon_question.png");
            this.imageList1.Images.SetKeyName(3, "icon_stop.png");
            this.imageList1.Images.SetKeyName(4, "icon_warning.png");
            // 
            // panelBtnContainer
            // 
            this.panelBtnContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBtnContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelBtnContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBtnContainer.Controls.Add(this.btnAbort);
            this.panelBtnContainer.Controls.Add(this.btnIgnore);
            this.panelBtnContainer.Controls.Add(this.btnRetry);
            this.panelBtnContainer.Controls.Add(this.btnNo);
            this.panelBtnContainer.Controls.Add(this.btnYes);
            this.panelBtnContainer.Controls.Add(this.btnCancel);
            this.panelBtnContainer.Controls.Add(this.btnOK);
            this.panelBtnContainer.Location = new System.Drawing.Point(-1, 95);
            this.panelBtnContainer.Name = "panelBtnContainer";
            this.panelBtnContainer.Size = new System.Drawing.Size(386, 48);
            this.panelBtnContainer.TabIndex = 3;
            // 
            // XMessageBox
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 141);
            this.Controls.Add(this.panelBtnContainer);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 160);
            this.Name = "XMessageBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.XMessageBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.XMessageBox_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelBtnContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private string message;
        private string title_text;
        private MessageBoxButtons msg_button = MessageBoxButtons.OK;
        private XMessageBoxIcon msg_icon = XMessageBoxIcon.None;
        private MessageBoxDefaultButton msg_def_button = MessageBoxDefaultButton.Button1;
        private List<Button> available_button = new List<Button>();

        private XMessageBox()
        {
            this.InitializeComponent();
        }

        private void XMessageBox_Load(object sender, EventArgs e)
        {
            this.txtMessage.Text = this.message;
            this.Text = this.title_text;

            switch (this.msg_button)
            {
                case MessageBoxButtons.OK:
                    this.available_button.Add(this.btnOK);
                    this.SetButtonPosition();
                    break;
                case MessageBoxButtons.OKCancel:
                    this.available_button.Add(this.btnOK);
                    this.available_button.Add(this.btnCancel);
                    this.SetButtonPosition();
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    this.available_button.Add(this.btnAbort);
                    this.available_button.Add(this.btnRetry);
                    this.available_button.Add(this.btnIgnore);
                    this.SetButtonPosition();
                    break;
                case MessageBoxButtons.YesNoCancel:
                    this.available_button.Add(this.btnYes);
                    this.available_button.Add(this.btnNo);
                    this.available_button.Add(this.btnCancel);
                    this.SetButtonPosition();
                    break;
                case MessageBoxButtons.YesNo:
                    this.available_button.Add(this.btnYes);
                    this.available_button.Add(this.btnNo);
                    this.SetButtonPosition();
                    break;
                case MessageBoxButtons.RetryCancel:
                    this.available_button.Add(this.btnRetry);
                    this.available_button.Add(this.btnCancel);
                    this.SetButtonPosition();
                    break;
                default:
                    this.available_button.Add(this.btnOK);
                    this.SetButtonPosition();
                    break;
            }

            foreach (var btn in this.available_button)
            {
                btn.Visible = true;
            }

            switch (this.msg_icon)
            {
                case XMessageBoxIcon.None:
                    this.pctIcon.Visible = false;
                    this.txtMessage.Dock = DockStyle.Fill;
                    break;
                case XMessageBoxIcon.Information:
                    this.pctIcon.Image = this.imageList1.Images["icon_info.png"];
                    break;
                case XMessageBoxIcon.Question:
                    this.pctIcon.Image = this.imageList1.Images["icon_question.png"];
                    break;
                case XMessageBoxIcon.Warning:
                    this.pctIcon.Image = this.imageList1.Images["icon_warning.png"];
                    break;
                case XMessageBoxIcon.Stop:
                    this.pctIcon.Image = this.imageList1.Images["icon_stop.png"];
                    break;
                case XMessageBoxIcon.Error:
                    this.pctIcon.Image = this.imageList1.Images["icon_error.png"];
                    break;
                default:
                    this.pctIcon.Visible = false;
                    this.txtMessage.Dock = DockStyle.Fill;
                    break;
            }

            switch (this.msg_def_button)
            {
                case MessageBoxDefaultButton.Button1:
                    if(this.available_button.Count >= 1)
                    {
                        this.ActiveControl = this.available_button[0];
                    }
                    break;
                case MessageBoxDefaultButton.Button2:
                    if(this.available_button.Count >= 2)
                    {
                        this.ActiveControl = this.available_button[1];
                    }
                    break;
                case MessageBoxDefaultButton.Button3:
                    if(this.available_button.Count >= 3)
                    {
                        this.ActiveControl = this.available_button[2];
                    }
                    break;
                default:
                    if (this.available_button.Count >= 1)
                    {
                        this.ActiveControl = this.available_button[0];
                    }
                    break;
            }
        }

        private void SetButtonPosition()
        {
            var margin_right = this.btnAbort.Location.X + this.btnAbort.Width;

            //for (int i = 0; i < this.available_button.Count; i++)
            for (int i = this.available_button.Count - 1; i > -1; i--)
            {
                this.available_button[i].SetBounds(margin_right - this.available_button[i].Width, this.available_button[i].Bounds.Y, this.available_button[i].Bounds.Width, this.available_button[i].Bounds.Height);

                margin_right -= this.available_button[i].Bounds.Width + 5;
            }
        }

        private void XMessageBox_Paint(object sender, PaintEventArgs e)
        {
            var size = TextRenderer.MeasureText(e.Graphics, this.message, this.Font, new Size(this.txtMessage.Width - SystemInformation.VerticalScrollBarWidth, this.txtMessage.Height), TextFormatFlags.WordBreak);

            var diff_height = size.Height - this.txtMessage.Height;

            this.Height += diff_height;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (this.btnCancel.Visible)
                {
                    this.btnCancel.PerformClick();
                    return true;
                }

                if(this.available_button.Count == 1 && this.available_button[0].Name == this.btnOK.Name)
                {
                    this.btnOK.PerformClick();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public static DialogResult Show(string message)
        {
            XMessageBox msgbox = new XMessageBox();
            msgbox.message = message;
            msgbox.title_text = string.Empty;

            return msgbox.ShowDialog();
        }


        public static DialogResult Show(string message, string title)
        {
            XMessageBox msgbox = new XMessageBox();
            msgbox.message = message;
            msgbox.title_text = title;
            
            return msgbox.ShowDialog();
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons msg_button)
        {
            XMessageBox msgbox = new XMessageBox();
            msgbox.message = message;
            msgbox.title_text = title;
            msgbox.msg_button = msg_button;

            return msgbox.ShowDialog();
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons msg_button, XMessageBoxIcon msg_icon)
        {
            XMessageBox msgbox = new XMessageBox();
            msgbox.message = message;
            msgbox.title_text = title;
            msgbox.msg_button = msg_button;
            msgbox.msg_icon = msg_icon;

            return msgbox.ShowDialog();
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons msg_button, XMessageBoxIcon msg_icon, MessageBoxDefaultButton msg_default_button)
        {
            XMessageBox msgbox = new XMessageBox();
            msgbox.message = message;
            msgbox.title_text = title;
            msgbox.msg_button = msg_button;
            msgbox.msg_icon = msg_icon;
            msgbox.msg_def_button = msg_default_button;

            return msgbox.ShowDialog();
        }
    }
}
