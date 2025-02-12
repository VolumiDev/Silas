<?php
require_once('../includes/User.class.php');

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    
    $body = json_decode(file_get_contents('php://input'), true);
    
    
    
    $id = $body['id'];
    
    User::addUserToCompany($id);
}

?>
