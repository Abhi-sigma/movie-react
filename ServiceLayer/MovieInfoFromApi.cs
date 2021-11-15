using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayer.Model;


namespace ServiceLayer
{
    public class MovieInfoFromApi
    {
        public string Title { get; set; }
        public string Actors { get; set; }
        public string Awards { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Released { get; set; }
        public string Year { get; set; }
        public int imdbrating { get; set; }
        public int imdbId { get; set; }

       
        
    }
}
//{ "Title":"Baaghi","Year":"2016","Rated":"Not Rated","Released":"29 Apr 2016","Runtime":"133 min","Genre":"Action, Thriller","Director":"Sabir Khan","Writer":"Shifuji Shaurya Bharadwaj (Wrote all of his own dialogue), Sanjeev Datta, Sanjeev Dutta (Writer)","Actors":"Shraddha Kapoor, Tiger Shroff, Sudheer Babu Posani, Paras Arora","Plot":"A martial arts student seeks revenge after the murder of his master.","Language":"Hindi","Country":"India","Awards":"1 win & 2 nominations.","Poster":"https://m.media-amazon.com/images/M/MV5BMDlhYzBmYjgtYzkyMC00MDUwLTkwNzgtYzk4Yjc5ZTU1ODI3XkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_SX300.jpg","Ratings":[{ "Source":"Internet Movie Database","Value":"5.2/10"},{ "Source":"Rotten Tomatoes","Value":"30%"}],"Metascore":"N/A","imdbRating":"5.2","imdbVotes":"6,866","imdbID":"tt4864932","Type":"movie","DVD":"N/A","BoxOffice":"$436,055","Production":"Benetone Films","Website":"N/A","Response":"True"}