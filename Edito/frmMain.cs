﻿using System;
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
        #region Initialize
        //Déclare la connection dont nous aurons besoin tout au long du projet
        DB _db;
        //Déclare les BindingList dont nous aurons besoin tout au long du projet
        BindingList<Article> _articles;
        BindingList<NewsPaper> _newsPapers;
        BindingList<Article> _articlesInNewspaper;
        BindingList<Association> _associations;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Appel la méthode que nous avons créé à la fin du document pour mettre en place les Bindings de notre projet
            InitializeBinding();
            //Initialisation de la connection
            _db = new();

        }
        /// <summary>
        /// Evenement se déclanchant quand nous changeons d'onglet
        /// </summary>
        private async void tabEdito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEdito.SelectedTab == tabArticles)
            {

                await RefreshArticles();
            }
            if (tabEdito.SelectedTab == tabJournaux)
            {
                await RefreshNP();
            }
        }
        #endregion
        #region Articles

        private async void btArticleActualiser_Click(object sender, EventArgs e)
        {
            await RefreshArticles();
        }
        private async Task RefreshArticles()
        {
            // creation du current
            Article current = bsArticles.Current as Article;
            // Remplissage de la liste
            _articles.Clear();
            var articles = await _db.GetArticlesAsync();
            foreach (Article a in articles)
                _articles.Add(a);
            // On se repositionne sur le current
            if (current is not null)
                bsArticles.Position = _articles.IndexOf(_articles.Where(u => u.IdArticle == current.IdArticle).FirstOrDefault());
        }

        private async void btArticleAjouter_Click(object sender, EventArgs e)
        {
            //Condition qui verifie que l'article n'existe pas déjà
            if (_articles.Where(article => article.Titre == tbxTitreArticle.Text && article.Auteur == tbxAuteurArticle.Text && article.Corps == tbxCorpsArticle.Text).Count() >= 1 || _articles.Where(article => article.Titre == tbxTitreArticle.Text && article.Auteur == null && article.Corps == tbxCorpsArticle.Text).Count() >= 1)
            {
                // si l'article existe deja un message est indiquer a l'utilisateur
                MessageBox.Show("L'article que vous voulez créé existe déjà", "Erreur de creation", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            //Si l'article n'est pas présent un message demendant la confirmation avec les information de l'article fournit
            if (MessageBox.Show($"Confirmer la creation de l'article \n nom : {tbxTitreArticle.Text} \n corps : {tbxCorpsArticle.Text} \n auteur : {tbxAuteurArticle.Text}", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // Si l'utilisateur répond positivement l'article est créé avec les information fournit
                var iDArticle = await _db.InsertArticleAsync(tbxTitreArticle.Text, tbxCorpsArticle.Text, tbxAuteurArticle.Text);
                await RefreshArticles();
                // Positionement sur l'article qui vient d'être créé
                bsArticles.Position = _articles.IndexOf(_articles.Where(u => u.IdArticle == iDArticle).FirstOrDefault());
                return;
            }
        }

        private async void btArticleModifier_Click(object sender, EventArgs e)
        {
            // creation du current
            Article current = bsArticles.Current as Article;
            // Verifie que la current n'est pas null
            if (current is not null)
            {
                // Requête classique de modification avec une ternaire sur l'auteur car il peut être null
                var nb = await _db.UpdateArticleAsync(current.IdArticle, tbxTitreArticle.Text, tbxCorpsArticle.Text, string.IsNullOrWhiteSpace(tbxAuteurArticle.Text) ? null : tbxAuteurArticle.Text);
                // La simulation du click sur le bouton btArticleRefresh permet d'avoir une actualisation directement aprés la création sans que l''utilisateur n'ai à appuyer sur le bouton
                await RefreshArticles();
            }
        }

        private async void btArticleSupprimer_Click(object sender, EventArgs e)
        {
            // creation du current
            Article current = bsArticles.Current as Article;
            // Verifie que la current n'est pas null
            if (current is not null)
            {
                // Message de confirmation de la supression de l'article
                if (MessageBox.Show($"Confirmez vous la suppression de l'article {current.Titre} ?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Supression de l'article si il est pas présent dans un journal
                    var nb = await _db.DeleteArticleIfNotExistAsync(current.IdArticle);
                    if (nb == 0)
                    {
                        MessageBox.Show($"L'article {current.Titre} est present dans un journal. Veuillez l'enlever du journal avant la supression", "Echec de supression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // La simulation du click sur le bouton btArticleRefresh permet d'avoir une actualisation directement aprés la création sans que l''utilisateur n'ai à appuyer sur le bouton
                    await RefreshArticles();
                }
            }

        }

        #endregion Articles
        #region NewsPaper
        private async void btNPRefresh_Click(object sender, EventArgs e)
        {
            await RefreshNP();
        }
        private async Task RefreshNP()
        {
            // creation du current
            NewsPaper current = bsArticles.Current as NewsPaper;
            // Remplissage de la liste des journaux
            _newsPapers.Clear();
            var NewsPaper = await _db.GetNewsPapersAsync();
            foreach (NewsPaper j in NewsPaper)
                _newsPapers.Add(j);
            // On se repositionne sur le current
            if (current is not null)
                bsNewsPaper.Position = _newsPapers.IndexOf(_newsPapers.Where(j => j.IDJournal == current.IDJournal).FirstOrDefault());
            // Remplissage de la liste d'association
            _associations.Clear();
            var asso = await _db.GetArticlesAssoAsync();
            foreach (Association a in asso)
                _associations.Add(a);
            // Remplissage de la liste d'articles
            NewsPaper currentNP = bsNewsPaper.Current as NewsPaper;
            Article currentArticle = bsArticles.Current as Article;
            var articles = await _db.GetArticlesAsync();
            _articles.Clear();
            // on verifie que currentNP n'est pas null
            if (currentNP is not null)
            {
                foreach (Article a in articles)
                    // Pour chaque Article on verifie sa presence dans le journal selectionné grâce à la liste _association
                    if (_associations.Where(id => id.IDJournal == currentNP.IDJournal && id.IdArticle == a.IdArticle).Count() < 1)
                    {
                        _articles.Add(a);
                    }
            }
        }
        private async void btAddNP_Click(object sender, EventArgs e)
        {
            // Verifie si le journal qui doit être créé existe déjà
            if (_newsPapers.Where(newspaper => newspaper.Titre == tbxTitleNewsPaper.Text && newspaper.DtParution == dtpNewsPaper.Value).Count() >= 1 || _newsPapers.Where(newspaper => newspaper.Titre == tbxTitleNewsPaper.Text && newspaper.DtParution == null).Count() >= 1)
            {
                // si le journal existe déjà un message l'indique a l'utilisateur
                MessageBox.Show("Le journal que vous voulez créé existe déjà", "Erreur de creation", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // Verification du check du Date Time Picker
            if (dtpNewsPaper.Checked == true)
            {
                // Un message avec un récapitulatife des informations demandées à l'utilisateur la validation de la creation 
                if (MessageBox.Show($"Confirmer la creation du journal \n nom : {tbxTitleNewsPaper.Text} \n date de parution {dtpNewsPaper.Text}", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // appel de la fonction InsertNewsPaper avec les information requise
                    var idNewsPaper = await _db.InsertNewsPaperAsync(tbxTitleNewsPaper.Text, dtpNewsPaper.Value);


                    // Positionement sur le journal qui vient d'être créé
                    bsNewsPaper.Position = _newsPapers.IndexOf(_newsPapers.Where(j => j.IDJournal == idNewsPaper).FirstOrDefault());
                    await RefreshNP();
                    return;
                }
            }
            // Même commentaire que pour le if precedent
            else
            {
                if (MessageBox.Show($"Confirmer la creation du journal \n nom : {tbxTitleNewsPaper.Text} \n sans date de parution", "Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    var idNewsPaper = await _db.InsertNewsPaperAsync(tbxTitleNewsPaper.Text, null);

                    await RefreshNP();

                    bsNewsPaper.Position = _newsPapers.IndexOf(_newsPapers.Where(j => j.IDJournal == idNewsPaper).FirstOrDefault());
                    return;
                }
            }
        }
        private async void btUpdateNP_Click(object sender, EventArgs e)
        {
            // creation du current
            NewsPaper current = bsNewsPaper.Current as NewsPaper;
            // Verifie que la current n'est pas null
            if (current is not null)
            {
                //Demande de confirmation à l'utilisateur pour la modification
                if (MessageBox.Show($"Confirmer la modification du journal {current.Titre} ?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    //verification du check du Date Time Picker du journal comme il apparait en BDD
                    if (dtpNewsPaper.Checked == true)
                    {
                        //verification du check du Date Time Picker du current
                        if (current.DtParution == null)
                        {
                            //Verification de l'execution de la requête
                            var nb2 = await _db.UpdateNewsPaperAsync(current.IDJournal, tbxTitleNewsPaper.Text, dtpNewsPaper.Value);
                            if (nb2 == 1)
                            {
                                // Mise en place d'un message recapitulatif selon le check du Date Time Picker
                                if (dtpNewsPaper.Checked == true)
                                {
                                    MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n  \n Date de naissance : {dtpNewsPaper.Text}", "Modifications effectuées");

                                }
                                else
                                {
                                    _db.UpdateNewsPaperAsync(current.IDJournal, tbxTitleNewsPaper.Text, null);
                                    MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n Date de parution : Sans date", "Modifications effectuées");
                                }

                                await RefreshNP();

                            }
                        }
                        var nb = await _db.UpdateNewsPaperAsync(current.IDJournal, tbxTitleNewsPaper.Text, dtpNewsPaper.Value);
                        if (nb == 1)
                        {
                            if (dtpNewsPaper.Checked == true)
                            {
                                MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n Date de parution : {dtpNewsPaper.Text}", "Modifications effectuées");

                            }
                            else
                            {
                                _db.UpdateNewsPaperAsync(current.IDJournal, tbxTitleNewsPaper.Text, null);
                                MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n Date de parution : Sans date", "Modifications effectuées");
                            }

                            await RefreshNP();
                        }
                    }
                    else if (dtpNewsPaper.Checked == false)
                    {
                        var nb = await _db.UpdateNewsPaperAsync(current.IDJournal, tbxTitleNewsPaper.Text, null);
                        if (nb == 1)
                        {
                            MessageBox.Show($"Les modifications du journal {current.Titre} ont étaient effectuées. \n Maintenant elles sont : \n Nom : {tbxTitleNewsPaper.Text} \n Date de parution : Sans date", "Modifications effectuées");
                        }

                        await RefreshNP();
                    }
            }
        }
        private async void btDeleteNP_Click(object sender, EventArgs e)
        {
            // creation du current
            NewsPaper current = bsNewsPaper.Current as NewsPaper;
            // Verifie que la current n'est pas null
            if (current is not null)
            {
                // Message de confirmation de la supression du journal
                if (MessageBox.Show($"Accepter la suppression du journal {current.Titre} ?", "Suprression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // Supression du journal dans la table composition & journal
                    await _db.DeleteNewsPaperCascadeAsync(current.IDJournal);

                    await RefreshNP();
                }
            }
        }
        private async void bsNewsPaper_CurrentChanged(object sender, EventArgs e)
        {
            // creation du current NewsPaper
            NewsPaper currentNP = bsNewsPaper.Current as NewsPaper;
            // Verifie que le current n'est pas null
            if (currentNP is not null)
            {
                // supprime les éléments present dans les liste _articles et _articlesInNewspaper
                _articles.Clear();
                _articlesInNewspaper.Clear();
                // Récupére les articles present dans le journal selectionner
                var ArticlesInNewspaper = await _db.GetArticlesInNewspaperAsync(currentNP.IDJournal);
                foreach (Article article in ArticlesInNewspaper)
                    // Les ajoute à la liste _articlesInNewspaper
                    _articlesInNewspaper.Add(article);
                _articles.Clear();
                // creation du current Article
                Article currentArticle = bsArticles.Current as Article;
                var articles = await _db.GetArticlesAsync();
                foreach (Article a in articles)
                    if (currentNP is not null)
                    {
                        // ajoute les article dans _articles si ils ne sont pas deja present dans le journal selectionné
                        if (_associations.Where(id => id.IDJournal == currentNP.IDJournal && id.IdArticle == a.IdArticle).Count() < 1)
                        {
                            _articles.Add(a);

                        }
                    }

            }
        }
        #endregion
        #region Articles and NewsPaper
        private void btAddArticle_Click(object sender, EventArgs e)
        {
            // creation du current NewsPaper
            NewsPaper currentNP = bsNewsPaper.Current as NewsPaper;
            // creation du current Article
            Article currentArticle = bsArticles.Current as Article;
            // Verification que les current ne sont pas null
            if (currentNP is not null && currentArticle is not null)
            {
                // insertion de l'article
                _db.InsertArticleInNewsPaperAsync(currentNP.IDJournal, currentArticle.IdArticle);
                // suprression de l'article dans _articles
                _articles.Remove(currentArticle);

                RefreshNP();

                // Positionement sur le journal
                bsNewsPaper.Position = _newsPapers.IndexOf(_newsPapers.Where(j => j.IDJournal == currentNP.IDJournal).FirstOrDefault());
            }
        }
        private void btDeleteArticle_Click(object sender, EventArgs e)
        {
            // creation du current NewsPaper
            NewsPaper currentNP = bsNewsPaper.Current as NewsPaper;
            // creation du current Article
            Article currentArticle = bsArticleInNewspaper.Current as Article;
            // creation du current Association
            Association currentAsso = bsAsso.Current as Association;
            //verification que currentNP n'est pas null
            if (currentNP is not null)
            {
                //verification que currentAsso n'est pas null
                if (currentAsso is not null)
                {
                    // supprime l'association entre l'article et le journal dans la BDD
                    _db.DelteArticleInNewsPaperAsync(currentNP.IDJournal, currentArticle.IdArticle);
                    // supprime l'article dans la liste des articles present dans la journal
                    _articlesInNewspaper.Remove(currentArticle);
                    // supprime l'association entre l'article et le journal dans _associations
                    _associations.Remove(currentAsso);
                    // ajoute l'article supprimé de la liste des article dans la journal dans la liste des articles
                    _articles.Add(currentArticle);
                }
            }

            RefreshNP();

            // Positionement sur le journal
            bsNewsPaper.Position = _newsPapers.IndexOf(_newsPapers.Where(j => j.IDJournal == currentNP.IDJournal).FirstOrDefault());
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
            _articlesInNewspaper = new BindingList<Article>();
            bsArticleInNewspaper.DataSource = _articlesInNewspaper;
            bsNewsPaper.DataSource = _newsPapers;
            dgvNewsPaper.DataSource = bsNewsPaper;
            tbxTitleNewsPaper.DataBindings.Add("text", bsNewsPaper, "Titre", false, DataSourceUpdateMode.Never);
            dtpNewsPaper.DataBindings.Add("text", bsNewsPaper, "DtParution", false, DataSourceUpdateMode.Never);
            dgvAddArticle.DataSource = bsArticles;
            dgvDeleteArticle.DataSource = bsArticleInNewspaper;
            dgvDeleteArticle.Columns["iDArticle"].Visible = false;
            #endregion
            #region Binding Association
            _associations = new BindingList<Association>();
            bsAsso.DataSource = _associations;
            #endregion
        }


    }
}

