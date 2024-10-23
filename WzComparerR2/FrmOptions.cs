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
                new ComboItem("広東語 (HKMS)"){ Value = "yue" },
                new ComboItem("簡体字中国語 (CMS)"){ Value = "zh-CN" },
                new ComboItem("スペイン語 (EMS-ES)"){ Value = "es" },
                new ComboItem("ドイツ語 (EMS-DE)"){ Value = "de" },
                new ComboItem("日本語 (JMS)"){ Value = "ja" },
                new ComboItem("繁体字中国語 (TMS)"){ Value = "zh-TW" },
                new ComboItem("フランス語 (EMS-FR)"){ Value = "fr" },
            });

            cmbMozhiBackend.Items.AddRange(new[]
            {
                new ComboItem("mozhi.aryak.me"){ Value = "https://mozhi.aryak.me" },
                new ComboItem("translate.bus-hit.me"){ Value = "https://translate.bus-hit.me" },
                new ComboItem("nyc1.mz.ggtyler.dev"){ Value = "https://nyc1.mz.ggtyler.dev" },
                new ComboItem("translate.projectsegfau.lt"){ Value = "https://translate.projectsegfau.lt" },
                new ComboItem("translate.nerdvpn.de"){ Value = "https://translate.nerdvpn.de" },
                new ComboItem("mozhi.ducks.party"){ Value = "https://mozhi.ducks.party" },
                new ComboItem("mozhi.frontendfriendly.xyz"){ Value = "https://mozhi.frontendfriendly.xyz" },
                new ComboItem("mozhi.pussthecat.org"){ Value = "https://mozhi.pussthecat.org" },
                new ComboItem("mo.zorby.top"){ Value = "https://mo.zorby.top" },
                new ComboItem("mozhi.adminforge.de"){ Value = "https://mozhi.adminforge.de" },
                new ComboItem("translate.privacyredirect.com"){ Value = "https://translate.privacyredirect.com" },
                new ComboItem("mozhi.canine.tools"){ Value = "https://mozhi.canine.tools" },
                new ComboItem("mozhi.gitro.xyz"){ Value = "https://mozhi.gitro.xyz" },
                new ComboItem("api.hikaricalyx.com"){ Value = "https://api.hikaricalyx.com/mozhi" },
            });

            cmbPreferredTranslateEngine.Items.AddRange(new[]
            {
                new ComboItem("Google"){ Value = 0 },
                new ComboItem("DeepL"){ Value = 1 },
                new ComboItem("DuckDuckGo / Bing"){ Value = 2 },
                new ComboItem("MyMemory"){ Value = 3 },
                new ComboItem("Yandex"){ Value = 4 },
                // new ComboItem("Naver Papago (非Mozhi)"){ Value = 5 },
                new ComboItem("Google (非Mozhi)"){ Value = 6 },
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

        public string MozhiBackend
        {
            get
            {
                return ((cmbMozhiBackend.SelectedItem as ComboItem)?.Value as string) ?? "https://mozhi.aryak.me";
            }
            set
            {
                var items = cmbMozhiBackend.Items.Cast<ComboItem>();
                var item = items.FirstOrDefault(_item => _item.Value as string == value)
                    ?? items.Last();
                item.Value = value;
                cmbMozhiBackend.SelectedItem = item;
            }
        }

        public int PreferredTranslateEngine
        {
            get
            {
                return ((cmbPreferredTranslateEngine.SelectedItem as ComboItem)?.Value as int?) ?? 0;
            }
            set
            {
                var items = cmbPreferredTranslateEngine.Items.Cast<ComboItem>();
                var item = items.FirstOrDefault(_item => _item.Value as int? == value)
                    ?? items.Last();
                item.Value = value;
                cmbPreferredTranslateEngine.SelectedItem = item;
            }
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
            var req = WebRequest.Create((cmbMozhiBackend.SelectedItem as ComboItem)?.Value + "/api/engines") as HttpWebRequest;
            req.Timeout = 15000;
            try
            {
                string respJson = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8).ReadToEnd();
                if (respJson.Contains("All Engines"))
                {
                    respText = "このMozhiサーバーは有効です。";
                }
                else
                {
                    respText = "このMozhiサーバーは無効です。";
                }
            }
            catch (WebException ex)
            {
                string respJson = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                respText = "このMozhiサーバーは無効です。";
            }
            catch (Exception ex)
            {
                respText = "不明なエラーが発生しました：" + ex;
            }
            MessageBoxEx.Show(respText);
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
            this.NxSecretKey = config.NxSecretKey;
            this.MozhiBackend = config.MozhiBackend;
            this.PreferredTranslateEngine = config.PreferredTranslateEngine;
            this.DesiredLanguage = config.DesiredLanguage;
            this.EnableTranslate = config.EnableTranslate;
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
            config.NxSecretKey = this.NxSecretKey;
            config.MozhiBackend = this.MozhiBackend;
            config.PreferredTranslateEngine = this.PreferredTranslateEngine;
            config.DesiredLanguage = this.DesiredLanguage;
            config.EnableTranslate = this.EnableTranslate;
        }
    }
}