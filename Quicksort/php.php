<?php
function quicksort(&$arr, $left = 0, $right = null) {
    if ($right === null) {
        $right = count($arr) - 1;
    }
    if ($left < $right) {
        $pivotIndex = partition($arr, $left, $right);
        quicksort($arr, $left, $pivotIndex - 1);
        quicksort($arr, $pivotIndex + 1, $right);
    }
}

function partition(&$arr, $left, $right) {
    $pivot = $arr[(int)(($left + $right) / 2)];
    $i = $left;
    $j = $right;
    while ($i <= $j) {
        while ($arr[$i] < $pivot) {
            $i++;
        }
        while ($arr[$j] > $pivot) {
            $j--;
        }
        if ($i <= $j) {
            $temp = $arr[$i];
            $arr[$i] = $arr[$j];
            $arr[$j] = $temp;
            $i++;
            $j--;
        }
    }
    return $i;
}

$arr = array();
for ($i = 0; $i < 9999999; $i++) {
    $arr[] = rand(0, 9999999);
}

$start = microtime(true);
quicksort($arr);
$duration = (microtime(true) - $start) * 1000;
echo "Time : " . $duration . " ms\n";
?>
