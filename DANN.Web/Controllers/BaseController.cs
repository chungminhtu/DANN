using MyPageLib.Models;
using MyPageWebApp.Commons;
using System.Web.Mvc;

namespace MyPageWebApp.Controllers
{
    public class BaseController : Controller
    {

        /*-------------------共通セッション情報 Common Session Information------------------*/
        public CurrentCustomer CommonSessionInformation { get; set; }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((Session["ReDirectToStep"] == null || (bool)Session["ReDirectToStep"] == false) && Request.RequestType == "GET" && !Request.Url.PathAndQuery.Contains(@"page?"))
						{
							#region ReDirectToStep=false
							Session["baseURL"] = Request.Url;
                CommonSessionInformation = Session[SessionConst.SESSION_CURRENTCUSTOMER] as CurrentCustomer;
                if (CommonSessionInformation != null)
                {
									#region Step1ok Step4chek Step4ok Step1timeout
                    if (Request.Url.OriginalString.Contains("step1ok"))
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step1ok", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
                    else if (Request.Url.OriginalString.Contains("step4check"))
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step4check", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
                    else if (Request.Url.OriginalString.Contains("step4ok"))
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step4ok", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
                    else if (Request.Url.OriginalString.Contains("step1timeout"))
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step1timeout", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
									#endregion
									#region StepStatusによるRedirect
                    else if (CommonSessionInformation.Step1Status != 2)
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step1", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
                    else if (CommonSessionInformation.Step2Status == 1 || CommonSessionInformation.Step2Status == 2)
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step2ng", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
                    else if ((CommonSessionInformation.Step2Status != 3))
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step2", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
                    else if (CommonSessionInformation.Step3Status == 1 || CommonSessionInformation.Step3Status == 2)
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step3ng", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
                    else if ((CommonSessionInformation.Step3Status != 3))
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step3", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
                    else if (CommonSessionInformation.MyPageStatus != 2)	//マイページステータス「有効」で無いユーザー
                    {
                        filterContext.Result = new RedirectResult(Url.Action("step4", "step"));
                        Session["ReDirectToStep"] = true;
                        return;
                    }
										#endregion
                    else
                    {
                        CommonSessionInformation = Session[SessionConst.SESSION_CURRENTCUSTOMER] as CurrentCustomer;
												//該当しないステータスでSTEP系のページが要求されたらTOPへ遷移させる
												if (Request.Url.OriginalString.Contains("step1") || Request.Url.OriginalString.Contains("step2") || Request.Url.OriginalString.Contains("step2_other") || Request.Url.OriginalString.Contains("step3"))
                        {
                            filterContext.Result = new RedirectResult(Url.Action("index", "home"));
                            Session["ReDirectToStep"] = false;
                        }
												//2015.7.15 T.Ebihara - 未予約・キャンセル・卒業済 の顧客はinfo系のページには遷移できない
												//2015.7.16 T.Ebihara - キャンセル・卒業済 の顧客はinfo系のページには遷移できない
												else if (Request.Url.OriginalString.Contains("/info/") &&  //info系のページを要求
												(
													//(CommonSessionInformation.Book.BookStateCD == 2) || //未予約
													(CommonSessionInformation.Book.BookStateCD == 11) ||	//キャンセル
													(CommonSessionInformation.Book.GradDate < System.DateTime.Today)	//卒業済
												))
												{
													filterContext.Result = new RedirectResult(Url.Action("index", "home"));
													Session["ReDirectToStep"] = false;
												}
                        else
                        {
                            Session["baseURL"] = Request.Url;
                            Session["ReDirectToStep"] = false;
                        }
                    }
                    Session["UserBaseUrl"] = CommonSessionInformation.UserID + "";
                }
                else
                {
                    filterContext.Result = new RedirectResult(Url.Action("member", "login"));
                    Session["baseURL"] = Request.Url;
                }
								#endregion
            }
            else
            {
                CommonSessionInformation = Session[SessionConst.SESSION_CURRENTCUSTOMER] as CurrentCustomer;
                Session["ReDirectToStep"] = false;
            }
            base.OnActionExecuting(filterContext);
        }
        /*--------------------------------------------------------------------------------*/

    }
}