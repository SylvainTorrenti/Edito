using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edito
{
    public partial class frmMain : Form
    {
        DB _db;
        BindingList<Article> _articles;
        BindingList<NewsPaper> _newsPapers;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitializeBinding();
            _db = new();
            btArticleRefresh.PerformClick();

        }

        private void tabEdito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEdito.SelectedTab == tabArticles)
            {
                btArticleRefresh.PerformClick();
            }
            if (tabEdito.SelectedTab == tabJournaux)
            {
                btNewsPaperRefresh.PerformClick();
            }
        }

        #region Articles

        private void btArticleActualiser_Click(object sender, EventArgs e)
        {
            // Sauvegarde du current
            Article current = bsArticles.Current as Article;
            // Remplissage de la liste
            _articles.Clear();
            var articles = _db.GetArticles();
            foreach (Article a in articles)
                _articles.Add(a);
            // On se repositionne sur le current
            if (current is not null)
                bsArticles.Position = _articles.IndexOf(_articles.Where(u => u.IdArticle == current.IdArticle).FirstOrDefault());
        }

        private void btArticleAjouter_Click(object sender, EventArgs e)
        {
            if (_articles.Where(article => article.Titre == tbxTitreArticle.Text && article.Auteur == tbxAuteurArticle.Text && article.Corps == tbxCorpsArticle.Text).Count() >= 1 || _articles.Where(article => article.Titre == tbxTitreArticle.Text && article.Auteur == null && article.Corps == tbxCorpsArticle.Text).Count() >= 1)
            {
                MessageBox.Show("L'article que vous voulez créé existe déjà", "Erreur de creation", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (MessageBox.Show($"Confirmer la creation de l'article \n nom : {tbxTitreArticle.Text} \n corps : {tbxCorpsArticle.Text} \n auteur : {tbxAuteurArticle.Text}", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var iDArticle = _db.InsertArticle(tbxTitreArticle.Text, tbxCorpsArticle.Text, tbxAuteurArticle.Text);
                btArticleRefresh.PerformClick();
                bsArticles.Position = _articles.IndexOf(_articles.Where(u => u.IdArticle == iDArticle).FirstOrDefault());
                return;
            }
        }

        private void btArticleModifier_Click(object sender, EventArgs e)
        {
            Article current = bsArticles.Current as Article;
            if (current is not null)
            {
                // Requête classique
                var nb = _db.UpdateArticle(current.IdArticle, tbxTitreArticle.Text, tbxCorpsArticle.Text, string.IsNullOrWhiteSpace(tbxAuteurArticle.Text) ? null : tbxAuteurArticle.Text);
                btArticleRefresh.PerformClick();
            }
        }

        private void btArticleSupprimer_Click(object sender, EventArgs e)
        {
            Article current = bsArticles.Current as Article;
            if (current is not null)
            {
                if (MessageBox.Show($"Confirmez vous la suppression de l'article {current.Titre} ?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // Requête classique
                    var nb = _db.DeleteArticle(current.IdArticle);
                    btArticleRefresh.PerformClick();
                }
            }

        }

        #endregion Articles
        #region NewsPaper
        private void btRefresh_Click(object sender, EventArgs e)
        {
            // Sauvegarde du current
            NewsPaper current = bsArticles.Current as NewsPaper;
            // Remplissage de la liste
            _newsPapers.Clear();
            var NewsPaper = _db.GetNewsPapers();
            foreach (NewsPaper j in NewsPaper)
                _newsPapers.Add(j);
            // On se repositionne sur le current
            if (current is not null)
                bsArticles.Position = _newsPapers.IndexOf(_newsPapers.Where(j => j.IDJournal == current.IDJournal).FirstOrDefault());
        }
        private void btAddNP_Click(object sender, EventArgs e)
        {
            if (_newsPapers.Where(newspaper => newspaper.Titre == tbxTitleNewsPaper.Text && newspaper.DtParution == dtpNewsPaper.Value).Count() >= 1 || _newsPapers.Where(newspaper => newspaper.Titre == tbxTitleNewsPaper.Text && newspaper.DtParution == null).Count() >= 1)
            {
                MessageBox.Show("Le journal que vous voulez créé existe déjà", "Erreur de creation", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (dtpNewsPaper.Checked == true)
            {
                if (MessageBox.Show($"Confirmer la creation du journal \n nom : {tbxTitleNewsPaper.Text} \n date de parution {dtpNewsPaper.Text}", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    var idNewsPaper = _db.InsertNewsPaper(tbxTitleNewsPaper.Text, dtpNewsPaper.Value);
                    btNewsPaperRefresh.PerformClick();
                    bsNewsPaper.Position = _newsPapers.IndexOf(_newsPapers.Where(j => j.IDJournal == idNewsPaper).FirstOrDefault());
                    return;
                }
            }
            else
            {
                if (MessageBox.Show($"Confirmer la creation du journal \n nom : {tbxTitleNewsPaper.Text} \n sans date de parution", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    var idNewsPaper = _db.InsertNewsPaper(tbxTitleNewsPaper.Text, null);
                    btNewsPaperRefresh.PerformClick();
                    bsNewsPaper.Position = _newsPapers.IndexOf(_newsPapers.Where(j => j.IDJournal == idNewsPaper).FirstOrDefault());
                    return;
                }
            }
        }
        private void btUpdateNP_Click(object sender, EventArgs e)
        {
            NewsPaper current = bsNewsPaper.Current as NewsPaper;
            if (current is not null)
            {
                if (MessageBox.Show($"Confirmer la modification du journal {current.Titre} ?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    if (dtpNewsPaper.Checked == true)
                    {
                        if (current.DtParution == null)
                        {
                            var nb2 = _db.UpdateNewsPaper(current.IDJournal, tbxTitleNewsPaper.Text, dtpNewsPaper.Value);
                            if (nb2 == 1)
                            {
                                if (dtpNewsPaper.Checked == true)
                                {
                                    MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n  \n Date de naissance : {dtpNewsPaper.Text}", "Modifications effectuées");

                                }
                                else
                                {
                                    _db.UpdateNewsPaper(current.IDJournal, tbxTitleNewsPaper.Text, null);
                                    MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n Date de parution : Sans date", "Modifications effectuées");
                                }
                                btNewsPaperRefresh.PerformClick();

                            }
                        }
                        var nb = _db.UpdateNewsPaper(current.IDJournal, tbxTitleNewsPaper.Text, dtpNewsPaper.Value);
                        if (nb == 1)
                        {
                            if (dtpNewsPaper.Checked == true)
                            {
                                MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n Date de parution : {dtpNewsPaper.Text}", "Modifications effectuées");

                            }
                            else
                            {
                                _db.UpdateNewsPaper(current.IDJournal, tbxTitleNewsPaper.Text, null);
                                MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n Date de parution : Sans date", "Modifications effectuées");
                            }
                            btNewsPaperRefresh.PerformClick();
                        }
                    }
                    else if (dtpNewsPaper.Checked == false)
                    {
                        var nb = _db.UpdateNewsPaper(current.IDJournal, tbxTitleNewsPaper.Text, null);
                        if (nb == 1)
                        {
                            MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n Date de parution : Sans date", "Modifications effectuées");
                        }
                        btNewsPaperRefresh.PerformClick();
                    }
            }
        }
        private void btDeleteNP_Click(object sender, EventArgs e)
        {
            NewsPaper current = bsNewsPaper.Current as NewsPaper;
            if (current is not null)
            {
                if (MessageBox.Show($"Accepter la suppression du journal {current.Titre} ?", "Suprression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _db.DeleteNewsPaper(current.IDJournal);
                    btNewsPaperRefresh.PerformClick();
                }

            }
        }
        #endregion
        private void InitializeBinding()
        {
            #region Binding Article
            _articles = new BindingList<Article>();
            bsArticles.DataSource = _articles;
            dgvArticles.DataSource = bsArticles;
            dgvArticles.Columns["IdArticle"].Visible = false;
            tbxTitreArticle.DataBindings.Add("Text", bsArticles, "Titre", false, DataSourceUpdateMode.Never);
            tbxCorpsArticle.DataBindings.Add("Text", bsArticles, "Corps", false, DataSourceUpdateMode.Never);
            tbxAuteurArticle.DataBindings.Add("Text", bsArticles, "Auteur", false, DataSourceUpdateMode.Never);
            #endregion
            #region Binding NewsPaper
            _newsPapers = new BindingList<NewsPaper>();
            bsNewsPaper.DataSource = _newsPapers;
            dgvNewsPaper.DataSource = bsNewsPaper;
            tbxTitleNewsPaper.DataBindings.Add("text", bsNewsPaper, "Titre", false, DataSourceUpdateMode.Never);
            dtpNewsPaper.DataBindings.Add("text", bsNewsPaper, "DtParution", false, DataSourceUpdateMode.Never);
            dgvAddArticle.DataSource = bsArticles;
            dgvDeleteArticle.DataSource = bsArticles;
            #endregion
        }
    }
}
