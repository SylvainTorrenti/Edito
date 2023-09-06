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

        public DB()
        {
            _dbConnection = new(Settings.Default.EditoConnectionString);
        }
        #region Articles

        public IEnumerable<Article> GetArticles()
        {
            try
            {
                _dbConnection.Open();
                var q = "SELECT * from article";
                return _dbConnection.Query<Article>(q);
            }
            finally { _dbConnection.Close(); }
        }

        public int InsertArticle(string titre, string corps, string auteur)
        {
            try
            {
                _dbConnection.Open();
                var q = "INSERT INTO article (Titre,Corps,Auteur) VALUES (@titre, @corps, @auteur); SELECT LAST_INSERT_ID()";
                var result = _dbConnection.Query<int>(q, new { titre, corps, auteur });
                return result.Single();
            }
            finally { _dbConnection.Close(); }
        }

        public int UpdateArticle(int id, string titre, string corps, string auteur)
        {
            try
            {
                _dbConnection.Open();
                var q = "UPDATE Article SET Titre = @titre, Corps = @corps, Auteur = @auteur WHERE IDArticle = @id";
                var result = _dbConnection.Execute(q, new { id, titre, corps, auteur });
                return result;
            }
            finally { _dbConnection.Close(); }
        }

        public int DeleteArticle(int id)
        {
            try
            {
                _dbConnection.Open();
                var q = "DELETE from article WHERE IDArticle = @id";
                var result = _dbConnection.Execute(q, new { id });
                return result;
            }
            finally { _dbConnection.Close(); }
        }

        #endregion Articles
        #region NewsPaper
        public IEnumerable<NewsPaper> GetNewsPapers()
        {
            try
            {
                _dbConnection.Open();
                var q = "SELECT * from journal";
                return _dbConnection.Query<NewsPaper>(q);
            }
            finally { _dbConnection.Close(); }
        }
        public int InsertNewsPaper(string Titre, DateTime? DtParution)
        {
            try
            {
                _dbConnection.Open();
                var q = "INSERT INTO journal (Titre, DtParution) VALUES (@Titre, @DtParution); SELECT LAST_INSERT_ID() ";
                var result = _dbConnection.Query<int>(q, new { Titre, DtParution });
                return result.Single();
            }
            finally { _dbConnection.Close(); }
        }
        public int UpdateNewsPaper(int IDNewsPaper, string Titre, DateTime? DtParution)
        {
            try
            {
                _dbConnection.Open();
                var sql = "UPDATE journal SET Titre = @Titre, DtParution = @DtParution  WHERE IDJournal = @IDNewsPaper ;";
                return _dbConnection.Execute(sql, new { IDNewsPaper, Titre, DtParution });

            }
            finally
            {
                _dbConnection.Close();
            }
        }
        public int DeleteNewsPaper(int IDNewsPaper)
        {
            try
            {
                _dbConnection.Open();
                var sql = "DELETE FROM journal WHERE IDJournal = @IDNewsPaper;";
                return _dbConnection.Execute(sql, new { IDNewsPaper });
            }
            finally
            {
                _dbConnection.Close();
            }
        }
        #endregion
        #region Articles and NewsPaper
        public IEnumerable<Association> GetArticlesAsso()
        {
            try
            {
                _dbConnection.Open();
                var q = "SELECT * from composition;";
                return _dbConnection.Query<Association>(q);
            }
            finally { _dbConnection.Close(); }
        }
        public IEnumerable<Article> GetArticlesInNewspaper(int id)
        {
            try
            {
                _dbConnection.Open();
                var q = "SELECT a.Titre , a.Corps , a.Auteur from article a join composition c on a.IDArticle = c.IDArticle join journal j on j.IDJournal = c.IDJournal WHERE c.IDJournal = @id";
                return _dbConnection.Query<Article>(q, new { id });
            }
            finally { _dbConnection.Close(); }
        }
        public int InsertArticleInNewsPaper(int idNP, int idArticle)
        {
            try
            {
                _dbConnection.Open();
                var q = "INSERT INTO composition (IDJournal, IDArticle) VALUES (@idNP, @idArticle);";
                return _dbConnection.Execute(q, new { idNP, idArticle });

            }
            finally { _dbConnection.Close(); }
        }
        #endregion
    }
}
