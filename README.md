# Password Manager Application

## Description

The Password Manager Application is a console-based tool designed to help users securely manage their passwords. The application allows users to store, retrieve, update, and delete passwords associated with various applications or websites. Passwords are encrypted and decrypted using a custom encryption utility to ensure security.

## Features

- **Encrypt and Decrypt Passwords**: Passwords are encrypted before being saved to ensure their security. Encryption and decryption are handled by the `EncryptionUtility` class.
- **Add or Change Passwords**: Users can add new passwords or update existing ones.
- **Retrieve Passwords**: Users can retrieve stored passwords for specific applications or websites.
- **Delete Passwords**: Users can remove passwords for applications or websites that are no longer needed.
- **Validate Inputs**: The application checks for valid characters in both usernames and passwords to prevent invalid entries.

## Components

### `EncryptionUtility` Class

This class handles encryption and decryption of passwords and validation of usernames and passwords.

- **Encrypt(string password)**: Encrypts a given password using a predefined character mapping.
- **Decrypt(string password)**: Decrypts an encrypted password back to its original form.
- **IsPasswordValid(string password)**: Validates if the password contains only allowed characters.
- **IsUsernameValid(string username)**: Validates if the username contains only allowed characters.

### `App` Class

The main class responsible for interacting with the user and managing password entries.

- **Run(string[] args)**: Entry point for the application, presenting the user with options to manage passwords.
- **ReadPasswords()**: Reads passwords from a file and decrypts them for use in the application.
- **SavePasswords()**: Encrypts and saves the current password entries to a file.
- **AddorChangePassword()**: Prompts the user to add or change a password.
- **GetPassword()**: Retrieves and displays the password for a specified application or website.
- **DeletePassword()**: Deletes a password entry for a specified application or website.
- **ListAllPasswords()**: Lists all stored passwords with their associated application or website names.

## Usage

1. **Run the Application**: Compile and run the `Program` class to start the application.
2. **Select an Option**: Choose from the following options:
   - `1. List all passwords`
   - `2. Add/Change password`
   - `3. Get password`
   - `4. Delete password`
   - `5. Exit`
3. **Follow Prompts**: Enter the required information based on the selected option to manage passwords.

## Example

```plaintext
Please select an option:
1. List all passwords
2. Add/Change password
3. Get password
4. Delete password
5. Exit

Your option is: 2

Please enter website/app name:
exampleSite
Please enter your password:
MySecurePassword123!
