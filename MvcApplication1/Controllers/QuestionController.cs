using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data;
namespace MvcApplication1.Controllers
{
    public class QuestionController : Controller
    {
        //
        // GET: /Question/

        public ActionResult Index()
        {
            ViewModel header = new ViewModel();
            ChatBotContext db = new ChatBotContext();
            if (db.ChatBot.Where(e => e.IsHeader == 1).ToList().Count == 0)
            {
                header.headerinfo = "";
            }
            else
            {
                header.headerinfo = db.ChatBot.Where(e => e.IsHeader == 1).FirstOrDefault().Desc;
            }
            return View(header);
        }

        [HttpPost]
        public ActionResult SaveQuestion(QuestionModel quesObj)
        {
            ChatBotContext db = new ChatBotContext();

            chatbot c = new chatbot();
            c.IsHeader = 0;
            c.Desc = quesObj.Question;
            c.ContactId = Convert.ToInt32(quesObj.QuestionContectId);
            c.ParentId = Convert.ToInt32(quesObj.QuestionParentId);
            c.LevelId = quesObj.QuestionNextLevelId;
            db.ChatBot.Add(c);
            db.SaveChanges();
            return Json(new { status = "true" });
        }


        [HttpPost]
        public ActionResult AddHeader(string header)
        {
            try
            {
                chatbot c = new chatbot();
                c.Desc = header;
                c.IsHeader = 1;
                c.LevelId = 0;
                c.ParentId = 0;
                c.ContactId = 0;
                ChatBotContext addHeader = new ChatBotContext();
                addHeader.ChatBot.Add(c);
                addHeader.SaveChanges();
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, data = "" });

            }
        }




        [HttpPost]
        public ActionResult GetAllQuestion()
        {
            try
            {
                ChatBotContext getAllQuest = new ChatBotContext();
                var qlist = getAllQuest.ChatBot.Where(e => e.IsHeader == 0).ToList();
                return Json(new { status = true, data = qlist });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, data = "" });

            }
        }




        public void DeleteQuestions()
        {
            try
            {
                ChatBotContext getAllQuest = new ChatBotContext();
                getAllQuest.Database.ExecuteSqlCommand("TRUNCATE TABLE Chatbot");
                Response.Redirect("Index");
            }
            catch (Exception ex)
            {
                //return Json(new { status = false, data = "" });

            }
        }


        public ActionResult ShowAllQuestions()
        {
            ViewModel header = new ViewModel();

            using (ChatBotContext cb = new ChatBotContext())
            {
                if (cb.ContactInfromation.ToList().Count > 0)
                {
                    header.ContactList = (from c in cb.ContactInfromation
                                          select new ContectLists
                                          {
                                              Address = c.Address,
                                              email = c.email,
                                              Id = c.id,
                                              name = c.name,
                                              phoneNumber = c.phoneNumber,
                                              website = c.website

                                          }).ToList();
                }


                if (cb.ChatBot.ToList().Count > 0)
                {
                    header.QuestionList = (from c in cb.ChatBot
                                          select new QuestionList
                                          {
                                              ContactId = c.ContactId,
                                              Desc = c.Desc,
                                              IsHeader = c.IsHeader,
                                              LevelId = c.LevelId,
                                              ParentId = c.ParentId,
                                              QID = c.QID

                                          }).ToList();

                }


                return View(header);

            }


        }

        public class QuestionModel
        {
            public string Header { get; set; }
            public string ContectId { get; set; }

            public string Question { get; set; }
            public string QuestionParentId { get; set; }
            public int QuestionNextLevelId { get; set; }
            public int QuestionContectId { get; set; }
        }

        public class childQuest
        {
            public string Question { get; set; }
            public string QuestionParentId { get; set; }
            public int QuestionNextLevelId { get; set; }

        }

    }
}
