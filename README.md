# JSON Serializer

## Overview  
This project implements a **custom JSON serialization** solution using **reflection in C#**. Instead of relying on libraries like `System.Text.Json` or `Newtonsoft.Json`, it manually extracts object properties and values to construct a JSON-formatted string. This approach provides a **lightweight and flexible** serialization method.  

## Features  
- **Manual Object Serialization**: Converts C# objects into JSON strings without external libraries.  
- **Reflection-Based Property Retrieval**: Dynamically extracts object properties and values. 

## Technologies Used  
- **C#** – Core programming language.  
- **Reflection** – Used to inspect and retrieve object properties dynamically.  


## Usage  
1. Create an object of any class.  
2. Call the custom serialization method to convert it into a JSON string.  
