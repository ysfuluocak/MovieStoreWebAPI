namespace Application.Features.CQRS.Queries.GetDirectorMoviesQuery
{
    public class GetDirectorMoviesQueryResponse
    {
        public string MovieName { get; set; }
        public string MovieDate { get; set; }
        public string Genre { get; set; }
        public string DirectorFullName { get; set; }

    }
}
