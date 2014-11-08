using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace iSpring
{
    public partial class AddBasic : Form
    {
        public XmlDocument XmlDoc { get; set; }
        public XmlDocument BasicDoc= new XmlDocument();
        public MetaEdit mee { get; set; }
        public AddBasic()
        {
            InitializeComponent();
            BasicDoc.InnerXml = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>" +
                "<metadata xmlns:dc=\"http:" + "//purl.org/dc/elements/1.1/\" xmlns:opf=\"http:" + "//www.idpf.org/2007/opf\">" +
                "<dc:contributor opf:role=\"app\">Applicant</dc:contributor>" +
                "<dc:contributor opf:role=\"arc\">Architect</dc:contributor>" +
                "<dc:contributor opf:role=\"arr\">Arranger</dc:contributor>" +
                "<dc:contributor opf:role=\"acp\">Art copyist</dc:contributor>" +
                "<dc:contributor opf:role=\"art\">Artist</dc:contributor>" +
                "<dc:contributor opf:role=\"ard\">Artistic director</dc:contributor>" +
                "<dc:contributor opf:role=\"asg\">Assignee</dc:contributor>" +
                "<dc:contributor opf:role=\"asn\">Associated name</dc:contributor>" +
                "<dc:contributor opf:role=\"att\">Attributed name</dc:contributor>" +
                "<dc:contributor opf:role=\"auc\">Auctioneer</dc:contributor>" +
                "<dc:contributor opf:role=\"aqt\">Author in quotations or text extracts</dc:contributor>" +
                "<dc:contributor opf:role=\"aft\">Author of afterword, colophon, etc.</dc:contributor>" +
                "<dc:contributor opf:role=\"aud\">Author of dialog</dc:contributor>" +
                "<dc:contributor opf:role=\"aui\">Author of introduction, etc.</dc:contributor>" +
                "<dc:contributor opf:role=\"aus\">Author of screenplay, etc.</dc:contributor>" +
                "<dc:contributor opf:role=\"ant\">Bibliographic antecedent</dc:contributor>" +
                "<dc:contributor opf:role=\"bnd\">Binder</dc:contributor>" +
                "<dc:contributor opf:role=\"bdd\">Binding designer</dc:contributor>" +
                "<dc:contributor opf:role=\"bkd\">Book designer</dc:contributor>" +
                "<dc:contributor opf:role=\"bkp\">Book producer</dc:contributor>" +
                "<dc:contributor opf:role=\"bjd\">Bookjacket designer</dc:contributor>" +
                "<dc:contributor opf:role=\"bpd\">Bookplate designer</dc:contributor>" +
                "<dc:contributor opf:role=\"cll\">Calligrapher</dc:contributor>" +
                "<dc:contributor opf:role=\"ctg\">Cartographer</dc:contributor>" +
                "<dc:contributor opf:role=\"cns\">Censor</dc:contributor>" +
                "<dc:contributor opf:role=\"chr\">Choreographer</dc:contributor>" +
                "<dc:contributor opf:role=\"cng\">Cinematographer</dc:contributor>" +
                "<dc:contributor opf:role=\"clb\">Collaborator</dc:contributor>" +
                "<dc:contributor opf:role=\"col\">Collector</dc:contributor>" +
                "<dc:contributor opf:role=\"clt\">Collotyper</dc:contributor>" +
                "<dc:contributor opf:role=\"cmm\">Commentator</dc:contributor>" +
                "<dc:contributor opf:role=\"cwt\">Commentator for written text</dc:contributor>" +
                "<dc:contributor opf:role=\"com\">Compiler</dc:contributor>" +
                "<dc:contributor opf:role=\"cpl\">Complainant</dc:contributor>" +
                "<dc:contributor opf:role=\"cpt\">Complainant-appellant</dc:contributor>" +
                "<dc:contributor opf:role=\"cpe\">Complainant-appellee</dc:contributor>" +
                "<dc:contributor opf:role=\"cmp\">Composer</dc:contributor>" +
                "<dc:contributor opf:role=\"cmt\">Compositor</dc:contributor>" +
                "<dc:contributor opf:role=\"ccp\">Conceptor</dc:contributor>" +
                "<dc:contributor opf:role=\"cnd\">Conductor</dc:contributor>" +
                "<dc:contributor opf:role=\"csl\">Consultant</dc:contributor>" +
                "<dc:contributor opf:role=\"csp\">Consultant to a project</dc:contributor>" +
                "<dc:contributor opf:role=\"cos\">Contestant</dc:contributor>" +
                "<dc:contributor opf:role=\"cot\">Contestant-appellant</dc:contributor>" +
                "<dc:contributor opf:role=\"coe\">Contestant-appellee</dc:contributor>" +
                "<dc:contributor opf:role=\"cts\">Contestee</dc:contributor>" +
                "<dc:contributor opf:role=\"ctt\">Contestee-appellant</dc:contributor>" +
                "<dc:contributor opf:role=\"cte\">Contestee-appellee</dc:contributor>" +
                "<dc:contributor opf:role=\"ctr\">Contractor</dc:contributor>" +
                "<dc:contributor opf:role=\"ctb\">Contributor</dc:contributor>" +
                "<dc:contributor opf:role=\"cpc\">Copyright claimant</dc:contributor>" +
                "<dc:contributor opf:role=\"crp\">Correspondent</dc:contributor>" +
                "<dc:contributor opf:role=\"cst\">Costume designer</dc:contributor>" +
                "<dc:contributor opf:role=\"cov\">Cover designer</dc:contributor>" +
                "<dc:contributor opf:role=\"cre\">Creator</dc:contributor>" +
                "<dc:contributor opf:role=\"cur\">Curator of an exhibition</dc:contributor>" +
                "<dc:contributor opf:role=\"dnc\">Dancer</dc:contributor>" +
                "<dc:contributor opf:role=\"dtc\">Data contributor</dc:contributor>" +
                "<dc:contributor opf:role=\"dtm\">Data manager</dc:contributor>" +
                "<dc:contributor opf:role=\"dte\">Dedicatee</dc:contributor>" +
                "<dc:contributor opf:role=\"dto\">Dedicator</dc:contributor>" +
                "<dc:contributor opf:role=\"dfd\">Defendant</dc:contributor>" +
                "<dc:contributor opf:role=\"dft\">Defendant-appellant</dc:contributor>" +
                "<dc:contributor opf:role=\"dfe\">Defendant-appellee</dc:contributor>" +
                "<dc:contributor opf:role=\"dgg\">Degree grantor</dc:contributor>" +
                "<dc:contributor opf:role=\"dln\">Delineator</dc:contributor>" +
                "<dc:contributor opf:role=\"dpc\">Depicted</dc:contributor>" +
                "<dc:contributor opf:role=\"dpt\">Depositor</dc:contributor>" +
                "<dc:contributor opf:role=\"dis\">Dissertant</dc:contributor>" +
                "<dc:contributor opf:role=\"dst\">Distributor</dc:contributor>" +
                "<dc:contributor opf:role=\"dnr\">Donor</dc:contributor>" +
                "<dc:contributor opf:role=\"drm\">Draftsman</dc:contributor>" +
                "<dc:contributor opf:role=\"dub\">Dubious author</dc:contributor>" +
                "<dc:contributor opf:role=\"edt\">Editor</dc:contributor>" +
                "<dc:contributor opf:role=\"elg\">Electrician</dc:contributor>" +
                "<dc:contributor opf:role=\"elt\">Electrotyper</dc:contributor>" +
                "<dc:contributor opf:role=\"egr\">Engraver</dc:contributor>" +
                "<dc:contributor opf:role=\"etr\">Etcher</dc:contributor>" +
                "<dc:contributor opf:role=\"exp\">Expert</dc:contributor>" +
                "<dc:contributor opf:role=\"fac\">Facsimilist</dc:contributor>" +
                "<dc:contributor opf:role=\"fld\">Field director</dc:contributor>" +
                "<dc:contributor opf:role=\"flm\">Film editor</dc:contributor>" +
                "<dc:contributor opf:role=\"fpy\">First party</dc:contributor>" +
                "<dc:contributor opf:role=\"frg\">Forger</dc:contributor>" +
                "<dc:contributor opf:role=\"fmo\">Former owner</dc:contributor>" +
                "<dc:contributor opf:role=\"fnd\">Funder</dc:contributor>" +
                "<dc:contributor opf:role=\"gis\">Geographic information specialist</dc:contributor>" +
                "<dc:contributor opf:role=\"hnr\">Honoree</dc:contributor>" +
                "<dc:contributor opf:role=\"hst\">Host</dc:contributor>" +
                "<dc:contributor opf:role=\"ilu\">Illuminator</dc:contributor>" +
                "<dc:contributor opf:role=\"ill\">Illustrator</dc:contributor>" +
                "<dc:contributor opf:role=\"ins\">Inscriber</dc:contributor>" +
                "<dc:contributor opf:role=\"itr\">Instrumentalist</dc:contributor>" +
                "<dc:contributor opf:role=\"ive\">Interviewee</dc:contributor>" +
                "<dc:contributor opf:role=\"ivr\">Interviewer</dc:contributor>" +
                "<dc:contributor opf:role=\"inv\">Inventor</dc:contributor>" +
                "<dc:contributor opf:role=\"lbr\">Laboratory</dc:contributor>" +
                "<dc:contributor opf:role=\"ldr\">Laboratory director</dc:contributor>" +
                "<dc:contributor opf:role=\"lsa\">Landscape architect</dc:contributor>" +
                "<dc:contributor opf:role=\"led\">Lead</dc:contributor>" +
                "<dc:contributor opf:role=\"len\">Lender</dc:contributor>" +
                "<dc:contributor opf:role=\"lil\">Libelant</dc:contributor>" +
                "<dc:contributor opf:role=\"lit\">Libelant-appellant</dc:contributor>" +
                "<dc:contributor opf:role=\"lie\">Libelant-appellee</dc:contributor>" +
                "<dc:contributor opf:role=\"lel\">Libelee</dc:contributor>" +
                "<dc:contributor opf:role=\"let\">Libelee-appellant</dc:contributor>" +
                "<dc:contributor opf:role=\"lee\">Libelee-appellee</dc:contributor>" +
                "<dc:contributor opf:role=\"lbt\">Librettist</dc:contributor>" +
                "<dc:contributor opf:role=\"lse\">Licensee</dc:contributor>" +
                "<dc:contributor opf:role=\"lso\">Licensor</dc:contributor>" +
                "<dc:contributor opf:role=\"lgd\">Lighting designer</dc:contributor>" +
                "<dc:contributor opf:role=\"ltg\">Lithographer</dc:contributor>" +
                "<dc:contributor opf:role=\"lyr\">Lyricist</dc:contributor>" +
                "<dc:contributor opf:role=\"mfr\">Manufacturer</dc:contributor>" +
                "<dc:contributor opf:role=\"mrk\">Markup editor</dc:contributor>" +
                "<dc:contributor opf:role=\"mdc\">Metadata contact</dc:contributor>" +
                "<dc:contributor opf:role=\"mte\">Metal-engraver</dc:contributor>" +
                "<dc:contributor opf:role=\"mod\">Moderator</dc:contributor>" +
                "<dc:contributor opf:role=\"mon\">Monitor</dc:contributor>" +
                "<dc:contributor opf:role=\"mcp\">Music copyist</dc:contributor>" +
                "<dc:contributor opf:role=\"msd\">Musical director</dc:contributor>" +
                "<dc:contributor opf:role=\"mus\">Musician</dc:contributor>" +
                "<dc:contributor opf:role=\"nrt\">Narrator</dc:contributor>" +
                "<dc:contributor opf:role=\"opn\">Opponent</dc:contributor>" +
                "<dc:contributor opf:role=\"orm\">Organizer of meeting</dc:contributor>" +
                "<dc:contributor opf:role=\"org\">Originator</dc:contributor>" +
                "<dc:contributor opf:role=\"oth\">Other</dc:contributor>" +
                "<dc:contributor opf:role=\"own\">Owner</dc:contributor>" +
                "<dc:contributor opf:role=\"ppm\">Papermaker</dc:contributor>" +
                "<dc:contributor opf:role=\"pta\">Patent applicant</dc:contributor>" +
                "<dc:contributor opf:role=\"pth\">Patent holder</dc:contributor>" +
                "<dc:contributor opf:role=\"pat\">Patron</dc:contributor>" +
                "<dc:contributor opf:role=\"prf\">Performer</dc:contributor>" +
                "<dc:contributor opf:role=\"pma\">Permitting agency</dc:contributor>" +
                "<dc:contributor opf:role=\"pht\">Photographer</dc:contributor>" +
                "<dc:contributor opf:role=\"ptf\">Plaintiff</dc:contributor>" +
                "<dc:contributor opf:role=\"ptt\">Plaintiff-appellant</dc:contributor>" +
                "<dc:contributor opf:role=\"pte\">Plaintiff-appellee</dc:contributor>" +
                "<dc:contributor opf:role=\"plt\">Platemaker</dc:contributor>" +
                "<dc:contributor opf:role=\"prt\">Printer</dc:contributor>" +
                "<dc:contributor opf:role=\"pop\">Printer of plates</dc:contributor>" +
                "<dc:contributor opf:role=\"prm\">Printmaker</dc:contributor>" +
                "<dc:contributor opf:role=\"prc\">Process contact</dc:contributor>" +
                "<dc:contributor opf:role=\"pro\">Producer</dc:contributor>" +
                "<dc:contributor opf:role=\"pmn\">Production manager</dc:contributor>" +
                "<dc:contributor opf:role=\"prd\">Production personnel</dc:contributor>" +
                "<dc:contributor opf:role=\"prg\">Programmer</dc:contributor>" +
                "<dc:contributor opf:role=\"pdr\">Project director</dc:contributor>" +
                "<dc:contributor opf:role=\"pfr\">Proofreader</dc:contributor>" +
                "<dc:contributor opf:role=\"pbd\">Publishing director</dc:contributor>" +
                "<dc:contributor opf:role=\"ppt\">Puppeteer</dc:contributor>" +
                "<dc:contributor opf:role=\"rcp\">Recipient</dc:contributor>" +
                "<dc:contributor opf:role=\"rce\">Recording engineer</dc:contributor>" +
                "<dc:contributor opf:role=\"red\">Redactor</dc:contributor>" +
                "<dc:contributor opf:role=\"ren\">Renderer</dc:contributor>" +
                "<dc:contributor opf:role=\"rpt\">Reporter</dc:contributor>" +
                "<dc:contributor opf:role=\"rps\">Repository</dc:contributor>" +
                "<dc:contributor opf:role=\"rth\">Research team head</dc:contributor>" +
                "<dc:contributor opf:role=\"rtm\">Research team member</dc:contributor>" +
                "<dc:contributor opf:role=\"res\">Researcher</dc:contributor>" +
                "<dc:contributor opf:role=\"rsp\">Respondent</dc:contributor>" +
                "<dc:contributor opf:role=\"rst\">Respondent-appellant</dc:contributor>" +
                "<dc:contributor opf:role=\"rse\">Respondent-appellee</dc:contributor>" +
                "<dc:contributor opf:role=\"rpy\">Responsible party</dc:contributor>" +
                "<dc:contributor opf:role=\"rsg\">Restager</dc:contributor>" +
                "<dc:contributor opf:role=\"rev\">Reviewer</dc:contributor>" +
                "<dc:contributor opf:role=\"rbr\">Rubricator</dc:contributor>" +
                "<dc:contributor opf:role=\"sce\">Scenarist</dc:contributor>" +
                "<dc:contributor opf:role=\"sad\">Scientific advisor</dc:contributor>" +
                "<dc:contributor opf:role=\"scr\">Scribe</dc:contributor>" +
                "<dc:contributor opf:role=\"scl\">Sculptor</dc:contributor>" +
                "<dc:contributor opf:role=\"spy\">Second party</dc:contributor>" +
                "<dc:contributor opf:role=\"sec\">Secretary</dc:contributor>" +
                "<dc:contributor opf:role=\"std\">Set designer</dc:contributor>" +
                "<dc:contributor opf:role=\"sgn\">Signer</dc:contributor>" +
                "<dc:contributor opf:role=\"sng\">Singer</dc:contributor>" +
                "<dc:contributor opf:role=\"sds\">Sound designer</dc:contributor>" +
                "<dc:contributor opf:role=\"spk\">Speaker</dc:contributor>" +
                "<dc:contributor opf:role=\"spn\">Sponsor</dc:contributor>" +
                "<dc:contributor opf:role=\"stm\">Stage manager</dc:contributor>" +
                "<dc:contributor opf:role=\"stn\">Standards body</dc:contributor>" +
                "<dc:contributor opf:role=\"str\">Stereotyper</dc:contributor>" +
                "<dc:contributor opf:role=\"stl\">Storyteller</dc:contributor>" +
                "<dc:contributor opf:role=\"sht\">Supporting host</dc:contributor>" +
                "<dc:contributor opf:role=\"srv\">Surveyor</dc:contributor>" +
                "<dc:contributor opf:role=\"tch\">Teacher</dc:contributor>" +
                "<dc:contributor opf:role=\"tcd\">Technical director</dc:contributor>" +
                "<dc:contributor opf:role=\"ths\">Thesis advisor</dc:contributor>" +
                "<dc:contributor opf:role=\"trc\">Transcriber</dc:contributor>" +
                "<dc:contributor opf:role=\"trl\">Translator</dc:contributor>" +
                "<dc:contributor opf:role=\"tyd\">Type designer</dc:contributor>" +
                "<dc:contributor opf:role=\"tyg\">Typographer</dc:contributor>" +
                "<dc:contributor opf:role=\"vdg\">Videographer</dc:contributor>" +
                "<dc:contributor opf:role=\"voc\">Vocalist</dc:contributor>" +
                "<dc:contributor opf:role=\"wit\">Witness</dc:contributor>" +
                "<dc:contributor opf:role=\"wde\">Wood-engraver</dc:contributor>" +
                "<dc:contributor opf:role=\"wdc\">Woodcutter</dc:contributor>" +
                "<dc:contributor opf:role=\"wam\">Writer of accompanying material</dc:contributor>" +
                "<dc:contributor opf:role=\"bsl\">书商</dc:contributor>" +
                "<dc:contributor opf:role=\"aut\">作者</dc:contributor>" +
                "<dc:publisher>出版</dc:publisher>"+
                "<dc:contributor opf:role=\"anl\">分析师</dc:contributor>" +
                "<dc:contributor opf:role=\"anm\">动画师</dc:contributor>" +
                "<dc:contributor opf:role=\"cli\">客户端</dc:contributor>" +
                "<dc:contributor opf:role=\"drt\">导演</dc:contributor>" +
                "<dc:contributor opf:role=\"eng\">工程师</dc:contributor>" +
                "<dc:contributor opf:role=\"adp\">改编者</dc:contributor>" +
                "<dc:contributor opf:role=\"crr\">校正者</dc:contributor>" +
                "<dc:contributor opf:role=\"cph\">著作权者</dc:contributor>" +
                "<dc:contributor opf:role=\"act\">表演者</dc:contributor>" +
                "<dc:contributor opf:role=\"dsr\">设计师</dc:contributor>" +
                "<dc:contributor opf:role=\"ann\">评注者</dc:contributor>" +
                "</metadata>";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    string temp = listBox1.SelectedItems[i].ToString();
                    foreach (XmlNode xn in BasicDoc.SelectSingleNode("metadata"))
                    {
                        if (temp == xn.InnerText)
                        {
                            if (mee != null) mee.addBasic(xn);
                        }
                    }
                }
            } 
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBasic_Load(object sender, EventArgs e)
        {
            foreach (XmlNode xn in BasicDoc.SelectSingleNode("metadata"))
            {
                listBox1.Items.Add(xn.InnerText);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString().Length > 0)
            {
                foreach (XmlNode xn in BasicDoc.SelectSingleNode("metadata"))
                {
                    if (listBox1.SelectedItem.ToString() == xn.InnerText)
                    {
                        if (mee != null) mee.addBasic(xn);
                    }
                }
            }
        }
    }
}
