namespace SuggestionBoxAPI.Migrations
{
    using Core.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuggestionBoxAPI.Persistence.SuggestionBoxContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SuggestionBoxAPI.Persistence.SuggestionBoxContext";
        }

        protected override void Seed(SuggestionBoxAPI.Persistence.SuggestionBoxContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.TypeOfSuggestions.AddOrUpdate(
              new TypeSuggestion { Title = "Sugerencias de la charla", Caption = "¿Tienes algún comentario acerca de la charla?" },
              new TypeSuggestion { Title = "¿Tienes preguntas?", Caption = "¿Tienes algún comentario acerca de la charla?" },
              new TypeSuggestion { Title = "Sugerencias al instructor", Caption = "¿Deseas sugerir algún comentario al instructor?" }
            );

        }
    }
}
