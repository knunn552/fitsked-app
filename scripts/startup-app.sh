#!/bin/bash

# Check if required environment variables are set
if [ -z "$DB_CONNECTION_STRING" ] || [ -z "$MS_SQL_PASSWORD" ]; then
    echo "ERROR: One or more required environment variables are missing or empty."
    exit 1
fi

# Replace placeholder in connection string with the actual password
export DB_CONNECTION_STRING=$(echo "$DB_CONNECTION_STRING" | sed "s/{PASSWORD_PLACEHOLDER}/$MS_SQL_PASSWORD/g")

# Log the updated connection string (for debugging purposes, remove in production)
echo "Updated DB_CONNECTION_STRING: $DB_CONNECTION_STRING"

# Start the Blazor app
exec dotnet FitskedApp.dll
