﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.Editors;
using WzComparerR2.Config;
using System.Security.Policy;
using System.IO;
using Spine;

namespace WzComparerR2
{
    public partial class FrmOptions : DevComponents.DotNetBar.Office2007Form
    {
        public FrmOptions()
        {
            InitializeComponent();
#if NET6_0_OR_GREATER
            // https://learn.microsoft.com/en-us/dotnet/core/compatibility/fx-core#controldefaultfont-changed-to-segoe-ui-9pt
            this.Font = new Font(new FontFamily("MS PGothic"), 9f);
#endif

            cmbWzEncoding.Items.AddRange(new[]
            {
                new ComboItem("ｼｽﾃﾑｴﾝｺｰﾃﾞｨﾝｸﾞ"){ Value = 0 },
                new ComboItem("Shift-JIS (JMS)"){ Value = 932 },
                new ComboItem("GB 2312 (CMS)"){ Value = 936 },
                new ComboItem("EUC-KR (KMS)"){ Value = 949 },
                new ComboItem("Big5 (TMS)"){ Value = 950 },
                new ComboItem("ISO 8859-1 (GMS)"){ Value = 1252 },
                new ComboItem("ASCII"){ Value = -1 },
            });

            cmbWzVersionVerifyMode.Items.AddRange(new[]
            {
                new ComboItem("高速な方法"){ Value = WzLib.WzVersionVerifyMode.Fast },
                new ComboItem("従来の方法"){ Value = WzLib.WzVersionVerifyMode.Default },
            });

            cmbDesiredLanguage.Items.AddRange(new[]
            {
                new ComboItem("英語 (GMS/MSEA)"){ Value = "en" },
                new ComboItem("オランダ語 (EMS-NL)"){ Value = "nl" },
                new ComboItem("韓国語 (KMS)"){ Value = "ko" },
                new ComboItem("簡体字中国語 (CMS)"){ Value = "zh-CN" },
                new ComboItem("スペイン語 (EMS-ES)"){ Value = "es" },
                new ComboItem("ドイツ語 (EMS-DE)"){ Value = "de" },
                new ComboItem("日本語 (JMS)"){ Value = "ja" },
                new ComboItem("繁体字中国語 (TMS)"){ Value = "zh-TW" },
                new ComboItem("フランス語 (EMS-FR)"){ Value = "fr" },
            });
        }

        public bool SortWzOnOpened
        {
            get { return chkWzAutoSort.Checked; }
            set { chkWzAutoSort.Checked = value; }
        }

        public bool SortWzByImgID
        {
            get { return chkWzSortByImgID.Checked; }
            set { chkWzSortByImgID.Checked = value; }
        }

        public int DefaultWzCodePage
        {
            get
            {
                return ((cmbWzEncoding.SelectedItem as ComboItem)?.Value as int?) ?? 0;
            }
            set
            {
                var items = cmbWzEncoding.Items.Cast<ComboItem>();
                var item = items.FirstOrDefault(_item => _item.Value as int? == value)
                    ?? items.Last();
                item.Value = value;
                cmbWzEncoding.SelectedItem = item;
            }
        }

        public bool AutoDetectExtFiles
        {
            get { return chkAutoCheckExtFiles.Checked; }
            set { chkAutoCheckExtFiles.Checked = value; }
        }

        public bool ImgCheckDisabled
        {
            get { return chkImgCheckDisabled.Checked; }
            set { chkImgCheckDisabled.Checked = value; }
        }

        public string NxOpenAPIKey
        {
            get { return txtAPIkey.Text; }
            set { txtAPIkey.Text = value; }
        }

        public string GCloudAPIKey
        {
            get { return txtGCloudTranslateAPIkey.Text; }
            set { txtGCloudTranslateAPIkey.Text = value; }
        }

        public string NxSecretKey
        {
            get { return txtSecretkey.Text; }
            set { txtSecretkey.Text = value;}
        }

        public bool EnableTranslate
        {
            get { return chkEnableTranslate.Checked; }
            set { chkEnableTranslate.Checked = value; }
        }

        public bool EnableCloudTranslateAPI
        {
            get { return chkUseAPI.Checked; }
            set { chkUseAPI.Checked = value; }
        }

        public string DesiredLanguage
        {
            get
            {
                return ((cmbDesiredLanguage.SelectedItem as ComboItem)?.Value as string) ?? "ja";
            }
            set
            {
                var items = cmbDesiredLanguage.Items.Cast<ComboItem>();
                var item = items.FirstOrDefault(_item => _item.Value as string == value)
                    ?? items.Last();
                item.Value = value;
                cmbDesiredLanguage.SelectedItem = item;
            }
        }
        private void buttonXCheck_Click(object sender, EventArgs e)
        {
            string respText;
            var req = WebRequest.Create(Program.NxAPIBaseURL + "/maplestory/v1/character/list") as HttpWebRequest;
            req.Timeout = 15000;
            req.Accept = "application/json";
            req.Headers.Add("x-nxopen-api-key", txtAPIkey.Text);
            try
            {
                string respJson = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8).ReadToEnd();
                Clipboard.SetText(respJson);
                respText = "この API キーは有効です。" + Environment.NewLine + "この API キーに関連付けられたキャラクターが JSON 形式でクリップボードにコピーされました。";
            }
            catch (WebException ex)
            {
                string respJson = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                respText = "この API キーは無効です。" + Environment.NewLine + respJson;
            }
            catch (Exception ex)
            {
                respText = "不明なエラーが発生しました：" + ex;
            }
            MessageBoxEx.Show(respText);
        }

        private void buttonXCheck2_Click(object sender, EventArgs e)
        {
            string respText;
            var req = WebRequest.Create(Program.GCloudAPIBaseURL + "/languages?key=" + txtGCloudTranslateAPIkey.Text) as HttpWebRequest;
            req.Timeout = 15000;
            req.Accept = "application/json";
            try
            {
                string respJson = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8).ReadToEnd();
                Clipboard.SetText(respJson);
                respText = "この API キーは有効です。" + Environment.NewLine + "この API キーに関連付けられたキャラクターが JSON 形式でクリップボードにコピーされました。";
            }
            catch (WebException ex)
            {
                string respJson = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                respText = "この API キーは無効です。" + Environment.NewLine + respJson;
            }
            catch (Exception ex)
            {
                respText = "不明なエラーが発生しました：" + ex;
            }
            MessageBoxEx.Show(respText);
        }

        private void chkUseAPI_Click(object sender, EventArgs e)
        {
            if (chkUseAPI.Checked)
            {
                txtGCloudTranslateAPIkey.Enabled = true;
                buttonXCheck2.Enabled = true;
            }
            else
            {
                txtGCloudTranslateAPIkey.Enabled = false;
                buttonXCheck2.Enabled = false;
            }
        }

        public WzLib.WzVersionVerifyMode WzVersionVerifyMode
        {
            get { return ((cmbWzVersionVerifyMode.SelectedItem as ComboItem)?.Value as WzLib.WzVersionVerifyMode?) ?? default; }
            set
            {
                var items = cmbWzVersionVerifyMode.Items.Cast<ComboItem>();
                var item = items.FirstOrDefault(_item => _item.Value as WzLib.WzVersionVerifyMode? == value)
                    ?? items.First();
                cmbWzVersionVerifyMode.SelectedItem = item;
            }
        }

        public void Load(WcR2Config config)
        {
            this.SortWzOnOpened = config.SortWzOnOpened;
            this.SortWzByImgID = config.SortWzByImgID;
            this.DefaultWzCodePage = config.WzEncoding;
            this.AutoDetectExtFiles = config.AutoDetectExtFiles;
            this.ImgCheckDisabled = config.ImgCheckDisabled;
            this.WzVersionVerifyMode = config.WzVersionVerifyMode;
            this.NxOpenAPIKey = config.NxOpenAPIKey;
            this.GCloudAPIKey = config.GCloudAPIKey;
            this.NxSecretKey = config.NxSecretKey;
            this.EnableTranslate = config.EnableTranslate;
            this.EnableCloudTranslateAPI = config.EnableCloudTranslateAPI;
            this.DesiredLanguage = config.DesiredLanguage;
        }

        public void Save(WcR2Config config)
        {
            config.SortWzOnOpened = this.SortWzOnOpened;
            config.SortWzByImgID = this.SortWzByImgID;
            config.WzEncoding = this.DefaultWzCodePage;
            config.AutoDetectExtFiles = this.AutoDetectExtFiles;
            config.ImgCheckDisabled = this.ImgCheckDisabled;
            config.WzVersionVerifyMode = this.WzVersionVerifyMode;
            config.NxOpenAPIKey = this.NxOpenAPIKey;
            config.GCloudAPIKey = this.GCloudAPIKey;
            config.NxSecretKey = this.NxSecretKey;
            config.EnableTranslate = this.EnableTranslate;
            config.EnableCloudTranslateAPI = this.EnableCloudTranslateAPI;
            config.DesiredLanguage = this.DesiredLanguage;
        }
    }
}