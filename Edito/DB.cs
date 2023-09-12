using Dapper;
using Edito.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edito
{
    internal class DB
    {
        private readonly MySqlConnection _dbConnection;

        #region Connection
        public DB()
        {
            _dbConnection = new(Settings.Default.EditoConnectionString);
        }
        #endregion
        #region Articles
        /// <summary>
        /// Récupére les articles
        /// </summary>
        /// <returns>IEnuerable d'Article</returns>
        public IEnumerable<Article> GetArticles()
        {
            try
            {
                _dbConnection.Open();
                //Recuperation de tout les champs de la table article
                var q = "SELECT * from article";
                return _dbConnection.Query<Article>(q);
            }
            finally { _dbConnection.Close(); }
        }
        /// <summary>
        /// Ajoute un article
        /// </summary>
        /// <param name="titre">Le titre de l'article</param>
        /// <param name="corps">Ce que l'article contient</param>
        /// <param name="auteur">L'auteur de l'article peut être null</param>
        /// <returns>L'id de l'article créé</returns>
        public int InsertArticle(string titre, string corps, string auteur)
        {
            try
            {
                _dbConnection.Open();
                //Insertion dans la table article avec comme valeur ce que nous avons fournit en paramétre
                //Ajout d'une 2eme requête à la suite nous permettant de recuperer le dernier ID créé "SELECT LAST_INSERT_ID()"
                var q = "INSERT INTO article (Titre,Corps,Auteur) VALUES (@titre, @corps, @auteur); SELECT LAST_INSERT_ID()";
                //Execution de la requête grâce à "q" et Passage des valeurs voulues grâce à "new { titre, corps, auteur }"
                var result = _dbConnection.Query<int>(q, new { titre, corps, auteur });
                //Return result.Single() car même si un seul ID est récuperer il le donne sous forme de liste et nous devons en récupérer qu'un seul pour pouvoir l'utiliser.
                return result.Single();
            }
            finally { _dbConnection.Close(); }
        }
        /// <summary>
        /// Mise a jour d'un article
        /// </summary>
        /// <param name="id">L'id de l'article à modifier</param>
        /// <param name="titre">Le titre aprés modification</param>
        /// <param name="corps">Le contenu aprés modification</param>
        /// <param name="auteur">L'auteur aprés modification</param>
        /// <returns></returns>
        public int UpdateArticle(int id, string titre, string corps, string auteur)
        {
            try
            {
                _dbConnection.Open();
                //Modification de l'article selectionné avec comme valeur ce que nous avons fournit en paramétre
                var q = "UPDATE article SET Titre = @titre, Corps = @corps, Auteur = @auteur WHERE IDArticle = @id";
                //Execution de la requête grâce à "q" et Passage des valeurs voulues grâce à "new { titre, corps, auteur }"
                var result = _dbConnection.Execute(q, new { id, titre, corps, auteur });
                return result;
            }
            finally { _dbConnection.Close(); }
        }
        /// <summary>
        /// Suppression d'un article
        /// </summary>
        /// <param name="id">L'id de l'article à supprimer</param>
        /// <returns></returns>
        public int DeleteArticleIfNotExist(int id)
        {
            try
            {
                _dbConnection.Open();
                //Suprression de l'article selectionné 
                var q = "DELETE from article WHERE IDArticle = @id AND NOT EXISTS (SELECT IDArticle from composition WHERE IDArticle = @id)";
                //Execution de la requête grâce à "q" et Passage des valeurs voulues grâce à "new { id }"
                var result = _dbConnection.Execute(q, new { id });
                return result;
            }
            finally { _dbConnection.Close(); }
        }
        #endregion Articles
        #region NewsPaper
        /// <summary>
        /// Recuperation des journaux
        /// </summary>
        /// <returns>IEnumerable de NewsPaper</returns>
        public IEnumerable<NewsPaper> GetNewsPapers()
        {
            try
            {
                _dbConnection.Open();
                //Recuperation de tout les champs de la table article
                var q = "SELECT * from journal";
                return _dbConnection.Query<NewsPaper>(q);
            }
            finally { _dbConnection.Close(); }
        }
        /// <summary>
        /// ajoute un journal
        /// </summary>
        /// <param name="Titre">Le titre du journal</param>
        /// <param name="DtParution">La date de parution du journal peut être null</param>
        /// <returns></returns>
        public int InsertNewsPaper(string Titre, DateTime? DtParution)
        {
            try
            {
                _dbConnection.Open();
                //Insertion dans la table article avec comme valeur ce que nous avons fournit en paramétre
                //Ajout d'une 2eme requête à la suite nous permettant de recuperer le dernier ID créé "SELECT LAST_INSERT_ID()"
                var q = "INSERT INTO journal (Titre, DtParution) VALUES (@Titre, @DtParution); SELECT LAST_INSERT_ID() ";
                //Execution de la requête grâce à "q" et Passage des valeurs voulues grâce à "new { titre, corps, auteur }"
                var result = _dbConnection.Query<int>(q, new { Titre, DtParution });
                //Return result.Single() car même si un seul ID est récuperer il le donne sous forme de liste et nous devons en récupérer qu'un seul pour pouvoir l'utiliser.
                return result.Single();
            }
            finally { _dbConnection.Close(); }
        }
        /// <summary>
        /// Modification du journal
        /// </summary>
        /// <param name="IDNewsPaper">L'id du journal à modifier</param>
        /// <param name="Titre">Titre du journal aprés modification</param>
        /// <param name="DtParution">Date de parution du journal aprés modification</param>
        /// <returns></returns>
        public int UpdateNewsPaper(int IDNewsPaper, string Titre, DateTime? DtParution)
        {
            try
            {
                _dbConnection.Open();
                //Modification du journal selectionné avec comme valeur ce que nous avons fournit en paramétre
                var sql = "UPDATE journal SET Titre = @Titre, DtParution = @DtParution  WHERE IDJournal = @IDNewsPaper ;";
                //Execution de la requête grâce à "q" et Passage des valeurs voulues grâce à "new { titre, corps, auteur }"
                return _dbConnection.Execute(sql, new { IDNewsPaper, Titre, DtParution });

            }
            finally
            {
                _dbConnection.Close();
            }
        }
        /// <summary>
        /// Suppression d'un journal
        /// </summary>
        /// <param name="IDNewsPaper">Id du journal à supprimer</param>
        /// <returns></returns>
        public int DeleteNewsPaperCascade(int IDNewsPaper)
        {
            try
            {
                _dbConnection.Open();
                using (var tran = _dbConnection.BeginTransaction())
                {
                    var sql = "DELETE FROM composition WHERE IDJournal = @IDNewsPaper";
                    var result = _dbConnection.Execute(sql, new { IDNewsPaper }, tran);

                    sql = "DELETE FROM journal WHERE IDJournal = @IDNewsPaper;";
                    result = _dbConnection.Execute(sql, new { IDNewsPaper }, tran);

                    tran.Commit();

                    return result;
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }
        #endregion
        #region Articles and NewsPaper
        /// <summary>
        /// Récupére les association entre les articles et les journaux
        /// </summary>
        /// <returns>IEnumerable d'Association</returns>
        public IEnumerable<Association> GetArticlesAsso()
        {
            try
            {
                _dbConnection.Open();
                //Recuperation de tout les champs de la table composition
                var q = "SELECT * from composition;";
                return _dbConnection.Query<Association>(q);
            }
            finally { _dbConnection.Close(); }
        }
        /// <summary>
        /// Récupére les articles present dans les journaux
        /// </summary>
        /// <param name="id">Id du journal selectionné</param>
        /// <returns>IEnumerable d'Article</returns>
        public IEnumerable<Article> GetArticlesInNewspaper(int id)
        {
            try
            {
                _dbConnection.Open();
                // récupére les champs : "IDArticle" , "Titre" , "Corps" , "Auteur" de la table article qui sont lié au journal fournit par l'IDJournal donné
                var q = "SELECT a.IDArticle , a.Titre , a.Corps , a.Auteur from article a join composition c on a.IDArticle = c.IDArticle join journal j on j.IDJournal = c.IDJournal WHERE c.IDJournal = @id";
                return _dbConnection.Query<Article>(q, new { id });
            }
            finally { _dbConnection.Close(); }
        }
        /// <summary>
        /// Insertion de l'article dans la journal
        /// </summary>
        /// <param name="idNP">L'identifiant du journal selectionné</param>
        /// <param name="idArticle">L'identifiant de l'article selectionné</param>
        /// <returns>Un int pour verifier que la requête c'est effectué correctement</returns>
        public int InsertArticleInNewsPaper(int idNP, int idArticle)
        {
            try
            {
                _dbConnection.Open();
                //Insert dans la table composition la liaison entre l'article et le journal donné grace à idNP et idArticle
                var q = "INSERT INTO composition (IDJournal, IDArticle) VALUES (@idNP, @idArticle);";
                return _dbConnection.Execute(q, new { idNP, idArticle });

            }
            finally { _dbConnection.Close(); }
        }
        /// <summary>
        /// Suppression de l'association entre l'article et le journal dans la table composition
        /// </summary>
        /// <param name="idNP">L'identifiant du journal selectionné</param>
        /// <param name="idArticle">L'identifiant de l'article selectionné</param>
        /// <returns>Un int pour verifier que la requête c'est effectué correctement</returns>
        public int DelteArticleInNewsPaper(int idNP, int idArticle)
        {
            try
            {
                _dbConnection.Open();
                //Supprime la liaison entre l'article et le journal grâce au Id donné 
                var q = "DELETE FROM composition WHERE IDJournal = @idNP AND IDArticle = @idArticle;";
                return _dbConnection.Execute(q, new { idNP, idArticle });

            }
            finally { _dbConnection.Close(); }
        }
        #endregion
    }
}
