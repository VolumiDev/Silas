<?php
require_once('../includes/User.class.php');

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    
    $body = json_decode(file_get_contents('php://input'), true);
    
    
    
    $email = $body['email'];
    
    User::exist_email($body['email']);
}

?>
