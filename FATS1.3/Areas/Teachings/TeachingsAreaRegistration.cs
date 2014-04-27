using System.Web.Mvc;

namespace FATS.Areas.Teachings
{
    public class TeachingsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Teachings";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Teachings_default",
                "Teachings/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
