import React, { useState } from 'react';
import axios from 'axios';

function AdminSearch(){
	const [search_query,set_search_query] = useState("");
	const [rendered_suggestions,set_renderered_suggestions] = useState([]);
	const [db_status, set_db_state] = useState({ string_result: "Query DB,if not found,add buttons will be activated", status: false });
	const [request_url, set_request_url] = useState("../api/admin/omdbapi/?search_query =")


	const onSearchClick = e => {
		// make a network query here
		// on arrival of results
		// we will put that in state
		// hide the api key on production
		let input = e.target.value;
		//the axios needs to make api calls to our server which will fetch data
		//this will hide api key
		//actually we can also say if a movie with same name is already added

		axios.get(request_url + search_query)
		.then( res => {
			set_renderered_suggestions(res.data);

	})
	}

	const onChangeHandler = e => {
		let input = e.target.value;
		set_search_query(input);
	}

	const onChangeRadioHandler = e => {
		let search_type = e.currentTarget.value;
		if (search_type == "title") {
			set_request_url("../api/admin/omdbapi/?search_type=title&search_query=")
		}
		else {
			set_request_url("../api/admin/omdbapi/?search_type=id&search_query=")
        }
    }




		const queryHandler = e => {
			e.preventDefault();
			const query_string = e.target.previousElementSibling.value;
			// console.log(query_string);
			// make api request which should return true if found
			// for now enables the add input
			set_db_state({string_result:"query string not found,activating add inputs",status:true})

		}


		//const submitForm = e =>{
		//	e.preventDefault();
		//	// make put request
			
		//	let input = "";
	
		//	console.log(JSON.stringify(input))
			
		//	const headers = {
		//		'Content-Type': 'application/json; charset=utf-8',
				
		//	  }
		//	 axios.post("https://localhost:5001/api/weatherforecast/actor",JSON.stringify(input),{
		//		headers: headers
		//	})
		//	.then( res => {
				
		//		console.log(res.data)
		//	}).catch(
		//	function(error){

		//		console.log(error.response);
		//	}
		//)

		//}

	//public int MovieId { get; set; }
 //       public string Title { get; set; }
 //       public string Actors { get; set; }
 //       public string Awards { get; set; }
 //       public string Director { get; set; }
 //       public string Genre { get; set; }
 //       public string Language { get; set; }
 //       public string Plot { get; set; }
 //       public string Poster { get; set; }
 //       public DateTime Released { get; set; }
 //       public string Year { get; set; }
 //       public int imdbrating { get; set; }
 //       public int imdbId { get; set; }
 //       public DateTime InsertedDate { get; set; }
 //       public virtual ICollection < MovieDetail > MovieDetails { get; set; }

	return(

		<React.Fragment>
		<div className = "searchblock-wrapper">
			<div className = "search-input">
					<input onChange={onChangeHandler} className="form-control" value={search_query} type="text" placeholder="adminsearch" />
					<div id="search_type">
						<span>Search By</span>
						<div>
							<label>Search by Title</label>
							<input onChange={onChangeRadioHandler} id="search_type" type="radio" name="search_type" value="title" />
						</div>
						<div>
							<label>Search by Id</label>
							<input onChange={onChangeRadioHandler} id="search_type" type="radio" name="search_type" value="id" />
						</div>
						</div>
					<button className="btn btn-success" onClick={onSearchClick}>Search</button>
			</div>
		</div>

			{rendered_suggestions.Title ? [rendered_suggestions].map((item, index) =>
			 <React.Fragment key={index}>

		 	<div className ="search_movie_info">
			 	<img   src = {item.Poster} className = "image_suggestions"></img>
			 	<li   className ="suggestions_list" >Name of the movie: {item.Title} </li>
			 	<li   className ="suggestions_list" >Director: {item.Director} </li>
			 	<li   className ="suggestions_list" >Year Released: {item.Year} </li>
			 	<li   className ="suggestions_list" >Actors: {item.Actors} </li>
			 	<li   className ="suggestions_list" >Language: {item.Language} </li>
			 	<li   className ="suggestions_list" >Storyline: {item.Plot} </li>
		 	</div>
		 	<form className = "upload-form" action = "../api/admin/add" method = "post">
		 		<div className="form-group">
				    <label htmlFor="movie_title">Movie Name</label>
				    <input type="text" name = "Title" className = "form-control" id = "movie_title" aria-describedby="movie_title" readOnly value={item.Title}/>
				</div>
				<div className="form-group">
				    <label htmlFor="movie_postor">Movie Poster</label>
				    <input type="text" name = "Poster" className = "form-control" id = "movie_poster" aria-describedby="movie_title" readOnly value={item.Poster}/>
				</div>
				<div className="form-group">
				    <label htmlFor="movie_title_alternate">Alternate Movie Name</label>
				    <input type="text" name = "movie_alternate_title" className = "form-control" id = "movie_title_alternate" aria-describedby="movie_title" />
				    <small  className="form-text text-muted">provide an alternate title eg dubbed version</small>
				</div>
				<div className="form-group">
				    <label htmlFor="movie_tags">Movie Tags</label>
				    <input type="text" name = "Tags" className = "form-control" id = "movie_tags" aria-describedby="movie_title" />
				    <small  className="form-text text-muted">provide tags like horror,comedy seperated by comma</small>
				</div>
				<div className="form-group">
				    <label htmlFor="director">Director</label>
				    <input type="text" className="form-control" name = "Director" id="director" aria-describedby="director" readOnly value={item.Director}/>
				    <button onClick = {queryHandler} className="btn btn-primary">Query DB</button>
				    <small>{db_status.string_result}</small>
				    <div>
				    {db_status.status?
				    <input  name = "directorimg" type = "text" placeholder = "Enter image link"/>

				    :""}
				    </div>
				</div>
				<div className="form-group">
							<label htmlFor="released_year">Released Year</label>
							<input type="text" className="form-control" name="Released" id="released" aria-describedby="released" readOnly value={new Date(item.Year).toString()} />
				</div>
				<div>
				{item.Actors?item.Actors.split(",").map((item,index) =>
				<div className="form-group" key = {index}>
				    <label htmlFor="actor_name">Actors</label>
						<input type="text" name={"MovieDetails["+index+"].Actor.Name"} className="form-control" aria-describedby="actor_name" readOnly value={item} />
					<label htmlFor="actor_name">Actors</label>
						<input type="text" name={"MovieDetails[" + index +"].Actor.ImageLink"} className="form-control" aria-describedby="actor_image"  />

				</div>
				):""}
				</div>
				<div className="form-group">
				    <label htmlFor="movie_language">Movie Language</label>
				    <input type="text" className="form-control" id="Language" aria-describedby="Language"  readOnly value={item.Language}/>
				</div>
				<div className="form-group">
				    <label htmlFor="movie_language">Imdb Rating</label>
				    <input type="text" className="form-control" id="imdbrating" aria-describedby="imdbrating"  readOnly value={item.imdbRating}/>
				</div>
				<div className="form-group">
				    <label htmlFor="movie_plot">Movie Plot</label>
				    <input type="text" className="form-control" id="Plot" aria-describedby="Plot" readOnly value={item.Plot}/>
				</div>
				<div className="form-group">
				    <label htmlFor="movie_link">Youtube Link</label>
				    <input type="text" className="form-control" id="youtube_link" name = "YouTubeLink" aria-describedby="youtube link" />
				</div>
				<button  className ="button" type = "submit">Submit</button>
		 	</form>

		 	</React.Fragment>



			) : <h1>{rendered_suggestions.msg}</h1>}
		 </React.Fragment>


)
	}





export default AdminSearch