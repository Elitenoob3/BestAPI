﻿namespace Project.DOTS.Movie;

public class DMovie
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    public List<DGenre> Genres { get; set; }
    public List<DCast> Cast { get; set; }
    
    public string VideoSourceUrl { get; set; }
    public string ImageUrl { get; set; }
}