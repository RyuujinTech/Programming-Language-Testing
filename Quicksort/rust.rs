use std::time::Instant;

fn quicksort(arr: &mut [i32]) {
    if arr.len() <= 1 {
        return;
    }
    let pivot_index = partition(arr);
    quicksort(&mut arr[0..pivot_index]);
    quicksort(&mut arr[pivot_index + 1..]);
}

fn partition(arr: &mut [i32]) -> usize {
    let pivot = arr[arr.len() / 2];
    let mut i = 0;
    let mut j = arr.len() - 1;
    loop {
        while arr[i] < pivot {
            i += 1;
        }
        while arr[j] > pivot {
            if j == 0 {
                break;
            }
            j -= 1;
        }
        if i >= j {
            return j;
        }
        arr.swap(i, j);
        i += 1;
        if j > 0 {
            j -= 1;
        }
    }
}

fn main() {
    let mut arr = (0..9999999).map(|_| rand::random::<i32>() % 9999999).collect::<Vec<_>>();

    let start = Instant::now();
    quicksort(&mut arr);
    let duration = start.elapsed().as_millis();
    println!("Time : {} ms", duration);
}
