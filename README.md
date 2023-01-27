# XML Serialization Basics

A beginner level task for practicing XML serialization with attributes.

In this task a student will learn the basics of XML serialization, will get acquainted with XML serialization attributes from `System.Xml.Serialization` namespace, and will learn how to use serialization attributes for managing the serialization process.

Before starting the task learn [how to use attributes in C#](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes).

Estimated time to complete the task: 2h.


## Task Description

**To complete the task, you need to take 9 steps**. Be aware that the order of XML elements is important for a successful unit test run. The task difficulty is growing from step to step, so the latest step is the most difficult.

To successfully complete the task, please review the article [XML and SOAP serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/xml-and-soap-serialization) and the first section of the article [XML serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/introducing-xml-serialization).


### 1. Serialize a Simple Class

First, read the following section: [Serialization of a Simple Class](https://learn.microsoft.com/en-us/dotnet/standard/serialization/introducing-xml-serialization#serialization-of-a-simple-class) and [Items That Can Be Serialized](https://learn.microsoft.com/en-us/dotnet/standard/serialization/introducing-xml-serialization#items-that-can-be-serialized).

Now, add auto-implemented properties with the public access modifier to the [SerializationWithoutAttributes/BookInfo](XmlSerializationBasics/SerializationWithoutAttributes/BookInfo.cs) class using information from the table below. Please be aware that the members' order affects the unit test results.

| Order | Member's Name   | Data Type | Member Type               | Access Modifier |
|-------|-----------------|-----------|---------------------------|-----------------|
| 1     | Title           | string    | Auto-implemented property | public          |
| 2     | Price           | decimal   | Auto-implemented property | public          |
| 3     | Genre           | string    | Auto-implemented property | public          |
| 4     | Isbn            | string    | Auto-implemented property | public          |
| 5     | PublicationDate | string    | Auto-implemented property | public          |

Then, review the article on [how to: serialize an object](https://learn.microsoft.com/en-us/dotnet/standard/serialization/how-to-serialize-an-object). Before moving to the next step, analyze the `SerializeAndCompareWithSample<T>` method in the [SerializationTestFixtureBase](XmlSerializationBasics.Tests/SerializationTestFixtureBase.cs#L21) class and figure out how _XmlSerializer_ class is used there.

Now, debug the [SerializeAndCompareWithSample](XmlSerializationBasics.Tests/SerializationWithoutAttributes/BookInfoTests.cs#L13) unit test in the [BookInfoTests.cs](XmlSerializationBasics.Tests/SerializationWithoutAttributes/BookInfoTests.cs) file and inspect the value of [actualXml](XmlSerializationBasics.Tests/SerializationTestFixtureBase.cs#L25) variable.


### 2. Control the Object Serialization with the XmlElement Attribute

Read the article [Attributes That Control XML Serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/attributes-that-control-xml-serialization).

Apply `XmlRootAttribute` attribute with `ElementName` property to the [SerializationWithXmlElement/BookInfo](XmlSerializationBasics/SerializationWithXmlElement/BookInfo.cs) class to set `book` as the XML root element name. 

Code sample:

```cs
[XmlRoot(ElementName = "book")]
public class BookInfo
```

Add auto-implemented properties with specified access modifier to the `BookInfo` class using information from the table below.
Now, apply the `XmlElementAttribute` attributes with `ElementName` properties to set XML element names.

| Order | Member's Name   | Data Type |  Member Type               | Access Modifier | XML Element Name      |
|-------|-----------------|-----------|----------------------------|-----------------|-----------------------|
| 1     | Title           | string    | Auto-implemented property  | public          | book-title            |
| 2     | Price           | decimal   | Auto-implemented property  | public          | book-price            |
| 3     | Genre           | string    | Auto-implemented property  | public          | book-genre            |
| 4     | Isbn            | string    | Auto-implemented property  | public          | book-isbn             |
| 5     | PublicationDate | string    | Auto-implemented property  | public          | book-publication-date |

Code sample:

```cs
[XmlElement(ElementName = "book-title")]
public string Title { get; set; }
```


### 3. Customize the Object Serialization with the Namespace and Order Properties

Copy the `BookInfo` class from step 2 to the [SerializationWithOrder/BookInfo](XmlSerializationBasics/SerializationWithOrder/BookInfo.cs) class.  

Both `XmlRootAttribute` and `XmlElementAttribute` attributes have constructors that allow setting the name of an XML element. Read the documentation pages for `XmlRootAttribute` and `XmlElementAttribute` constructors and use the constructors to set the name for XML elements.

Code sample:

```cs
[XmlRoot("book")]
public class BookInfo
```

Use the `Namespace` property of the `XmlRootAttribute` class to set [contoso.com/book](http://contoso.com/book) URI as the namespace for the root element of the `BookInfo` class:

```cs
[XmlRoot("book", Namespace = "http://contoso.com/book")]
public class BookInfo
```

Use the `Order` property of the `XmlElementAttribute` class to set the order of the element in the XML file as indicated in the XML Element Order column:

| Order | Member's Name   | Data Type | Member Type               | Access Modifier | XML Element Name      | XML Element Order |
|-------|-----------------|-----------|---------------------------|-----------------|-----------------------|-------------------|
| 1     | Title           | string    | Auto-implemented property | public          | book-title            | 1                 |
| 2     | Price           | decimal   | Auto-implemented property | public          | book-price            | 5                 |
| 3     | Genre           | string    | Auto-implemented property | public          | book-genre            | 4                 |
| 4     | Isbn            | string    | Auto-implemented property | public          | book-isbn             | 3                 |
| 5     | PublicationDate | string    | Auto-implemented property | public          | book-publication-date | 2                 |

Code sample:

```cs
[XmlElement("book-title", Order = 1)]
public string Title { get; set; }
```


### 4. Serialize a Class with Fields

Apply the `XmlRootAttribute` attribute to the [FieldsSerialization/BookInfo](XmlSerializationBasics/FieldsSerialization/BookInfo.cs) class to set `book.info` as the name for the root XML element and [contoso.com/book-info](http://contoso.com/book-info) URI as the namespace.

| XML Root Element Name | XML Root Element Namespace   |
|-----------------------|------------------------------|
| book.info             | http://contoso.com/book-info |

Apply the `XmlElementAttribute` attributes for the fields `Price` and `Genre` as well as for the properties `Title`, `Isbn`, and `PublicationDate` to set the name and the order of the elements as in the table below:

| Order | Member's Name   | Data Type |  Member Type               | Access Modifier | XML Element Name      | XML Element Order |
|-------|-----------------|-----------|----------------------------|-----------------|-----------------------|-------------------|
| 1     | Price           | decimal   | Field                      | public          | sell.price            | 4                 |
| 2     | Genre           | string    | Field                      | public          | category              | 1                 |
| 3     | isbn            | string    | Field                      | private         | -                     | -                 |
| 4     | publicationDate | string    | Field                      | private         | -                     | -                 |
| 5     | Title           | string    | Auto-implemented property  | public          | book.title            | 2                 |
| 3     | Isbn            | string    | Property                   | public          | book.number           | 5                 |
| 4     | PublicationDate | string    | Property                   | public          | pub.date              | 3                 |

Fields `ISBN` and `publicationDate` should not be serialized, so apply the `XmlIgnoreAttribute` attribute to these fields.

Run unit tests, inspect the `actualResult`, and analyze the expected XML file [fields-serialization.xml](XmlSerializationBasics.Tests/FieldsSerialization/fields-serialization.xml).

*Note:* The use of public fields instead of properties is [a bad practice for production applications](https://softwareengineering.stackexchange.com/questions/161303/is-it-bad-practice-to-use-public-fields). We use public fields in this task only for demonstration purposes. Read more about the benefits of properties in the article by Jon Skeet ["Why Properties Matter"](https://csharpindepth.com/articles/PropertiesMatter).


### 5. Control the Object Serialization with the XmlAttribute Attribute

Apply the `XmlRootAttribute` attribute to the [SerializationWithXmlAttributes/BookInfo](XmlSerializationBasics/SerializationWithXmlAttributes/BookInfo.cs) class using information from the table below:

| XML Root Element Name | XML Root Element Namespace |
|-----------------------|----------------------------|
| book                  | http://contoso.com/book    |

Add auto-implemented properties with the specified access modifier to the `BookInfo` class using information from the table below. The, apply `XmlAttributeAttribute` attributes to specify that the `XmlSerializer` must serialize the class members as XML attributes:

| Order | Member's Name   | Data Type | Member Type                | Access Modifier | XML Attribute Name      |
|-------|-----------------|-----------|----------------------------|-----------------|-------------------------|
| 1     | Title           | string    | Auto-implemented property  | public          | title                   |
| 2     | Price           | decimal   | Auto-implemented property  | public          | price                   |
| 3     | Genre           | string    | Auto-implemented property  | public          | genre                   |
| 4     | Isbn            | string    | Auto-implemented property  | public          | isbn                    |
| 5     | PublicationDate | string    | Auto-implemented property  | public          | publication-date        |

Code sample:

```cs
[XmlAttribute("title")]
public string Title { get; set; }
```


### 6. Serialize Complex Structures

Apply `XmlRootAttribute`, `XmlElementAttribute`, and `XmlAttributeAttribute` to classes in the [ComplexStructures](XmlSerializationBasics/ComplexStructures) folder ([BookInfo](XmlSerializationBasics/ComplexStructures/BookInfo.cs), [BookTitle](XmlSerializationBasics/ComplexStructures/BookTitle.cs), [BookPrice](XmlSerializationBasics/ComplexStructures/BookPrice.cs), and [BookPublicationDate](XmlSerializationBasics/ComplexStructures/BookPublicationDate.cs)) and the class members to ensure correct serialization of the `BookInfo` class. The final XML file should look like [complex-structures.xml](XmlSerializationBasics.Tests/ComplexStructures/complex-structures.xml) XML file.


### 7. Serialize an Array as a Sequence of Elements

Read the section [Serializing an Array as a Sequence of Elements](https://learn.microsoft.com/en-us/dotnet/standard/serialization/controlling-xml-serialization-using-attributes#serializing-an-array-as-a-sequence-of-elements).

Analyze the expected XML file [sequence.xml](XmlSerializationBasics.Tests/Sequence/sequence.xml) and take the following steps:
* Add auto-implemented properties to the [Sequence/BookInfo](XmlSerializationBasics/Sequence/BookInfo.cs) class using the information from the table below.
* Apply the `XmlRootAttribute` attribute to the `BookInfo` class.
* Apply the `XmlElementAttribute` attributes to the properties.

| Order | Member's Name    | Data Type   | Member Type                | Access Modifier | XML Element Name                   | XML Element Order  |
|-------|------------------|-------------|----------------------------|-----------------|------------------------------------|--------------------|
| 1     | Titles           | string[]    | Auto-implemented property  | public          | title                              | 3                  |
| 2     | Prices           | decimal[]   | Auto-implemented property  | public          | price                              | 4                  |
| 3     | Genres           | string[]    | Auto-implemented property  | public          | genre                              | 1                  |
| 4     | Codes            | string[]    | Auto-implemented property  | public          | international-standard-book-number | 2                  |
| 5     | PublicationDates | string[]    | Auto-implemented property  | public          | publication-date                   | 5                  |


### 8. Serialize an Array of Objects

Read the sections [Serializing an Array of Objects](https://learn.microsoft.com/en-us/dotnet/standard/serialization/examples-of-xml-serialization#serializing-an-array-of-objects) and [Controlling Array Serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/controlling-xml-serialization-using-attributes#controlling-array-serialization).

Analyze the expected XML file [arrays.xml](XmlSerializationBasics.Tests/Arrays/arrays.xml) and take the following steps:
* Add auto-implemented properties to the [Arrays/BookInfo](XmlSerializationBasics/Arrays/BookInfo.cs) class using the information from the table below.
* Apply the `XmlRootAttribute` attribute to the `BookInfo` class.
* Apply the `XmlArrayAttribute` and `XmlArrayItemAttribute` attributes to the properties.

| Order | Member's Name    | Data Type   | Member Type                | Access Modifier | XML Array Element Name              | XML Array Element Item Name        | XML Element Order |
|-------|------------------|-------------|----------------------------|-----------------|-------------------------------------|------------------------------------|-------------------|
| 1     | Titles           | string[]    | Auto-implemented property  | public          | titles                              | title                              | 1                 |
| 2     | Prices           | decimal[]   | Auto-implemented property  | public          | prices                              | price                              | 5                 |
| 3     | Genres           | string[]    | Auto-implemented property  | public          | genres                              | genre                              | 2                 |
| 4     | Codes            | string[]    | Auto-implemented property  | public          | international-standard-book-numbers | international-standard-book-number | 4                 |
| 5     | PublicationDates | string[]    | Auto-implemented property  | public          | publication-dates                   | publication-date                   | 3                 |


### 9. Purchase Order

Read the section [Purchase Order Example](https://learn.microsoft.com/en-us/dotnet/standard/serialization/examples-of-xml-serialization#purchase-order-example). A similar data structure is used in this step.  

Analyze the expected XML file [purchase-order.xml](XmlSerializationBasics.Tests/PurchaseOrderExample/purchase-order.xml). Apply all necessary attributes from the [System.Xml.Serialization namespace](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization) to classes in the [PurchaseOrderExample](XmlSerializationBasics/PurchaseOrderExample) folder ([PurchaseOrder](XmlSerializationBasics/PurchaseOrderExample/PurchaseOrder.cs), [Address](XmlSerializationBasics/PurchaseOrderExample/Address.cs), [DeliveryDate](XmlSerializationBasics/PurchaseOrderExample/DeliveryDate.cs), and [OrderedItem](XmlSerializationBasics/PurchaseOrderExample/OrderedItem.cs)) to ensure that the actual XML produced by `XmlSerializer` conforms to the expected XML file.  


## See Also

* C# Programming Guide
  * [Auto-Implemented Properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties)
  * [Access Modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)
  * [Attributes](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes)  
* .NET API
  * [XmlSerializer Class](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer)
  * [XmlRootAttribute Class](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlrootattribute)
  * [XmlElementAttribute Class](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlelementattribute)
  * [XmlAttributeAttribute Class](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlattributeattribute)
  * [XmlIgnore Class](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlignoreattribute)
  * [XmlArrayAttribute Class](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlarrayattribute)
  * [XmlArrayItemAttribute Class](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlarrayitemattribute)
