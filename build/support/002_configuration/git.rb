configs ={
  :git => {
    :user => '20111121iqmetrix',
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
