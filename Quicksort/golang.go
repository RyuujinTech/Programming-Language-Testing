package main

import (
	"fmt"
	"math/rand"
	"time"
)

func quicksort(arr []int) {
	if len(arr) <= 1 {
		return
	}
	pivotIndex := partition(arr)
	quicksort(arr[:pivotIndex])
	quicksort(arr[pivotIndex+1:])
}

func partition(arr []int) int {
	pivot := arr[len(arr)/2]
	i, j := 0, len(arr)-1
	for {
		for arr[i] < pivot {
			i++
		}
		for arr[j] > pivot {
			j--
		}
		if i >= j {
			return j
		}
		arr[i], arr[j] = arr[j], arr[i]
		i++
		j--
	}
}

func main() {
	arr := make([]int, 9999999)
	for i := range arr {
		arr[i] = rand.Intn(9999999)
	}

	start := time.Now()
	quicksort(arr)
	duration := time.Since(start).Milliseconds()
	fmt.Printf("Time : %d ms\n", duration)
}
