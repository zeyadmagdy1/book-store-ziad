using Azure.Core;
using book_store_ziad.Data;
using book_store_ziad.Models.Authorr;
using book_store_ziad.Models.CeridetCardd;
using book_store_ziad.Models.IdentityCardd;
using Microsoft.EntityFrameworkCore;

namespace book_store_ziad.Repos.AuthorRepo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;
        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorDto authorDto)
        {
            Author author = new Author {
                 AuthorName = authorDto.AuthorName,
            };
            _context.authors.Add(author);
            _context.SaveChanges();
        }

        public List<AuthorDto> GetAuthorList()
        {
            var result = _context.authors.Select(x => new AuthorDto {AuthorName=x.AuthorName }).ToList();
            return result;
        }

        public List<AddAndGetAll> GetAllIdeantity() {
            var result = _context
                .authors
                .Include(x => x.identityCard)
                .Include(x => x.ceridetCards)
                .Select(x => new AddAndGetAll {
                    AuthorName = x.AuthorName,
                    ceridetCardDtos = x.ceridetCards.Select(x => new CeridetCardDto {
                        CeridetCardName = x.CeridetCardName,
                    }).ToList(),
                    identityCardDto = new IdentityCardDto {
                        IdentityCardName =x.AuthorName
                    },
                })
                .ToList();

            return result;
        }

        public void AddAllIdeantity(AddAndGetAll a1)
        {
            Author author = new Author {
                AuthorName =a1.AuthorName,
                ceridetCards = a1.ceridetCardDtos.Select(x => new CeridetCard {
                    CeridetCardName=x.CeridetCardName,
                }).ToList(),
                identityCard = new IdentityCard {
                     IdentityCardName =a1.identityCardDto.IdentityCardName,
                },               
            };
            _context.authors.Add(author);
            _context.SaveChanges();
        }
    }
}
