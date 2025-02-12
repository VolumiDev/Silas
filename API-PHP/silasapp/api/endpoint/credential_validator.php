<?php
require_once('../includes/User.class.php');

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    
    $body = json_decode(file_get_contents('php://input'), true);
    
    
    
    $email = $body['email'];
    $password = $body['password'];
    
    User::credential_validator($email, $password);
}

?>
