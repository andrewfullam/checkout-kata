﻿namespace CheckoutKata.Services.PromotionServices.Abstractions
{
    public interface IPromotions
    {
        double ApplyPromotions(int qty);

        string GetItem(string itemName);

        string GetPromotionDescription(string item);

        bool PromotionHit(int qty);
    }
}
