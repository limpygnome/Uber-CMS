﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using UberLib.Connector;

namespace UberCMS.Plugins
{
    public static class Articles
    {
        public static string enable(string pluginid, Connector conn)
        {
            string basePath = Misc.Plugins.getPluginBasePath(pluginid, conn);
            string error = null;
            // Reserve URLS
            if ((error = Misc.Plugins.reserveURLs(pluginid, null, new string[] { "article", "articles" }, conn)) != null)
                return error;
            // Install content
            if((error = Misc.Plugins.contentInstall(basePath + "\\Content")) != null)
                return error;
            // Install templates
            if ((error = Misc.Plugins.templatesInstall(basePath + "\\Templates", conn)) != null)
                return error;
            // Install SQL
            if ((error = Misc.Plugins.executeSQL(basePath + "\\SQL\\Install.sql", conn)) != null)
                return error;

            return null;
        }
        public static string disable(string pluginid, Connector conn)
        {
            string basePath = Misc.Plugins.getPluginBasePath(pluginid, conn);
            string error = null;
            // Unreserve base URLs
            if ((error = Misc.Plugins.unreserveURLs(pluginid, conn)) != null)
                return error;
            // Uninstall content
            if ((error = Misc.Plugins.contentUninstall(basePath + "\\Content")) != null)
                return error;
            // Uninstall templates
            if ((error = Misc.Plugins.templatesUninstall("articles", conn)) != null)
                return error;

            return null;
        }
        public static string uninstall(string pluginid, Connector conn)
        {
            string basePath = Misc.Plugins.getPluginBasePath(pluginid, conn);
            string error = null;
            // Unreserve all URLs
            if((error = Misc.Plugins.unreserveURLs(pluginid, conn)) != null)
                return error;
            // Uninstall SQL
            if ((error = Misc.Plugins.executeSQL(basePath + "\\SQL\\Uninstall.sql", conn)) != null)
                return error;

            return null;
        }
        public static void handleRequest(string pluginid, Connector conn, ref Misc.PageElements pageElements, HttpRequest request, HttpResponse response, ref string baseTemplateParent)
        {
            switch (request.QueryString["pg"])
            {
                case "article":
                    pageArticle(pluginid, conn, ref pageElements, request, response, ref baseTemplateParent);
                    break;
                case "articles":
                    pageArticles(pluginid, conn, ref pageElements, request, response, ref baseTemplateParent);
                    break;
                default:
                    pageCreateArticle(pluginid, conn, ref pageElements, request, response, ref baseTemplateParent);
                    break;
            }
        }
        public static void pageArticles(string pluginid, Connector conn, ref Misc.PageElements pageElements, HttpRequest request, HttpResponse response, ref string baseTemplateParent)
        {
        }
        public static void pageArticle(string pluginid, Connector conn, ref Misc.PageElements pageElements, HttpRequest request, HttpResponse response, ref string baseTemplateParent)
        {
        }
        public static void pageCreateArticle(string pluginid, Connector conn, ref Misc.PageElements pageElements, HttpRequest request, HttpResponse response, ref string baseTemplateParent)
        {
        }
        public static void handleRequestNotFound(string pluginid, Connector conn, ref Misc.PageElements pageElements, HttpRequest request, HttpResponse response, ref string baseTemplateParent)
        {
            if(Core.settings["articles"].getBool("handles_404"))
                pageCreateArticle(pluginid, conn, ref pageElements, request, response, ref baseTemplateParent);
        }
    }
}