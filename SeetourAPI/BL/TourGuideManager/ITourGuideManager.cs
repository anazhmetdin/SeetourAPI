﻿using SeetourAPI.DAL.DTO;

namespace SeetourAPI.BL.TourGuideManager
{
    public interface ITourGuideManager
    {
        public ICollection<TourCardDto>? TourCards(string tourguideId);
        public ICollection<TourCardDto>? UpcomingTourCards(string tourguideId);
        public ICollection<TourCardDto>? PastTourCards(string tourguideId);
    }
}