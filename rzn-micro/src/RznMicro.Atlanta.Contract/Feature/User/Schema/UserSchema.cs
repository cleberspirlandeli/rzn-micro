﻿using Amazon.DynamoDBv2.DataModel;
using RznMicro.Atlanta.Core.SchemaDynamoDB;
using System.Text.Json.Serialization;

namespace RznMicro.Atlanta.Contract.Feature.User.Schema;

[DynamoDBTable("users")]
public record UserSchema : SchemaDynamoDB
{
    [DynamoDBHashKey]
    [DynamoDBProperty("id")]
    public string IdUser { get; set; }

    [DynamoDBProperty("idAddress")]
    public string IdAddress { get; set; }

    [DynamoDBProperty("fullName")]
    public string FullName { get; set; }

    [DynamoDBProperty("dateBirth")]
    public string DateBirth { get; set; }

    [DynamoDBProperty("active")]
    public bool? Active { get; set; }

    [DynamoDBProperty("gender")]
    public int? Gender { get; set; }

    [DynamoDBProperty("avatarUrl")]
    public string AvatarUrl { get; set; }

    [DynamoDBProperty("avatarKeyName")]
    public string AvatarKeyName { get; set; }

    [DynamoDBProperty("zipCode")]
    public string ZipCode { get; set; }

    [DynamoDBProperty("street")]
    public string Street { get; set; }

    [DynamoDBProperty("number")]
    public int? Number { get; set; }

    [DynamoDBProperty("additionalInformation")]
    public string AdditionalInformation { get; set; }

    [DynamoDBProperty("typeOfAddress")]
    public int? TypeOfAddress { get; set; }

    /// <summary>
    /// This variable is necessary because DynamoDB doesn't have support for selecting case-insensitive
    /// The solution is to create a column-only search, make data for performance select
    /// </summary>
    [DynamoDBProperty("fullNameSearch")]
    public string FullNameSearch { get; set; }
}
