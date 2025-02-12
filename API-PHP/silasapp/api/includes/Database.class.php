<?php
    class Database {
        private $host = 'volumidev.duckdns.org';
        private $user = 'pepito1';
        private $password = 'pepito1';
        private $database = 'silas';
        
        public function getConnection(){
            $hostDB = "mysql:host=".$this->host.";dbname=".$this->database.";";

            try{
                $connection = new PDO($hostDB,$this->user,$this->password);
                $connection->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
                return $connection;
            }catch(PDOException $e){
                die("ERROR:".$e->getMessage());
            }
        }
    }
?>