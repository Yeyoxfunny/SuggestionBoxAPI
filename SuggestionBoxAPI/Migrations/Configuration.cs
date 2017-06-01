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
        }

        protected override void Seed(SuggestionBoxAPI.Persistence.SuggestionBoxContext context)
        {
            context.TypeOfSuggestions.AddOrUpdate(
              new TypeSuggestion { Id = 1, Title = "Sugerencias de la charla", Caption = "¿Tienes algún comentario acerca de la charla?", ImageUri = "localhost:60024/www/images/TypeSuggestions/icon_1.png" },
              new TypeSuggestion { Id = 2, Title = "Sugerencias al instructor", Caption = "¿Deseas sugerir algún comentario al instructor?", ImageUri = "localhost:60024/www/images/TypeSuggestions/icon_2.png" },
              new TypeSuggestion { Id = 3, Title = "¿Tienes preguntas?", Caption = "¿En qué podemos ayudarte?", ImageUri = "localhost:60024/www/images/TypeSuggestions/icon_3.png" },
              new TypeSuggestion { Id = 4, Title = "Feedback", Caption = "Envíanos alguna retroalimentación", ImageUri = "localhost:60024/www/images/TypeSuggestions/icon_4.png" }
            );

            context.SuggestionState.AddOrUpdate(
                new SuggestionState { Id = 1, Description = "Pendiente" },
                new SuggestionState { Id = 2, Description = "Leído" },
                new SuggestionState { Id = 3, Description = "Respondido" }
            );

            context.Suggestions.AddOrUpdate(
                new Suggestion
                {
                    Id = 1,
                    Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    UserName = "Sergio Morales",
                    Email = "sergiomorales811@gmail.com",
                    CreationDate = DateTime.Now,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    TypeSuggestionId = 1,
                    StateId = 1
                },
                new Suggestion
                {
                    Id = 2,
                    Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    UserName = "Danilo Hernandez",
                    Email = "smorales@intergrupo.com",
                    CreationDate = DateTime.Now,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    TypeSuggestionId = 1,
                    StateId = 1
                }
            );
        }
    }
}
