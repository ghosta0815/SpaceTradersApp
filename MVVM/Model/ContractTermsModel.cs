using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Class representing the terms of a contract
/// </summary>
public class ContractTermsModel
{
    /// <summary>
    /// The deadline for the contract.
    /// </summary>
    [JsonPropertyName("deadline")]
    public DateTime? Deadline { get; set; }

    /// <summary>
    /// Payments for the contract.
    /// </summary>
    [JsonPropertyName("payment")]
    public PaymentModel? Payment { get; set; }

    /// <summary>
    /// The cargo that needs to be delivered to fulfill the contract
    /// </summary>
    [JsonPropertyName("deliver")]
    public List<DeliverableModel>? Deliver { get; set; }
}


