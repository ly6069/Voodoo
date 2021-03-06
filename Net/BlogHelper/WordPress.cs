﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

using System.Net;

namespace Voodoo.Net.BlogHelper
{
    public class WordPress
    {

        protected string UserName { get; set; }

        protected string Password { get; set; }

        protected string Url { get; set; }

        protected AlexJamesBrown.JoeBlogs.WordPressWrapper wp;

        #region 实例化


        public WordPress(string url, string Username, string password)
        {
            this.Url = url;
            this.UserName = Username;
            this.Password = password;
        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        public void Login()
        {
            if (!Url.Contains("xmlrpc.php"))
            {
                Url += "xmlrpc.php";
            }
            wp = new AlexJamesBrown.JoeBlogs.WordPressWrapper(Url, UserName, Password);
        }
        #endregion

        #region  提交

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="p">帖子</param>
        /// <returns></returns>
        public bool Post(Post p)
        {
            try
            {
                wp.NewPost(new AlexJamesBrown.JoeBlogs.Structs.Post()
                {
                    categories = p.Tags,
                    dateCreated = DateTime.Now,
                    description = p.Content,
                    title = p.Title
                }, true);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <returns></returns>
        public bool Post(string Title, string Content)
        {
            return Post(Title, Content, "", "");
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <param name="Tag">标签</param>
        /// <param name="Class">分类</param>
        /// <returns></returns>
        public bool Post(string Title, string Content, string Tag, string Class)
        {
            try
            {
                wp.NewPost(new AlexJamesBrown.JoeBlogs.Structs.Post()
                {
                    categories = Tag.Split(',', ' ', ';'),
                    dateCreated = DateTime.Now,
                    description = Content,
                    title = Title
                }, true);

                return true;
            }
            catch
            {
                return false;
            }


        }
        #endregion

        #region 获取最近发布的帖子
        /// <summary>
        /// 获取最近发布的帖子
        /// </summary>
        /// <param name="TopNum">最新的多少条</param>
        /// <returns></returns>
        public List<Post> GetRecentPosts(int TopNum)
        {
            var Result = new List<Post>();
            var posts = wp.GetRecentPosts(TopNum);
            foreach (var p in posts)
            {
                Result.Add(new Post()
                {
                    Title = p.title,
                    Tags = p.categories,
                    Content = p.description,
                    CreateTime = p.dateCreated,
                    id = p.postid
                });
            }
            return Result;
        }
        #endregion

        #region 根据ID获取帖子
        /// <summary>
        /// 根据ID获取帖子
        /// </summary>
        /// <param name="id">帖子id</param>
        /// <returns></returns>
        public Post GetPost(string id)
        {
            var post = wp.GetPost(id);
            return new Post()
            {
                Tags = post.categories,
                Content = post.description,
                id = post.postid,
                CreateTime = post.dateCreated,
                Title = post.title
            };
        }
        #endregion

        #region 删除帖子
        /// <summary>
        /// 删除帖子
        /// </summary>
        /// <param name="id">帖子ID</param>
        /// <returns></returns>
        public bool DeletePost(string id)
        {
            return wp.DeletePost(id);
        }
        #endregion


    }
}
